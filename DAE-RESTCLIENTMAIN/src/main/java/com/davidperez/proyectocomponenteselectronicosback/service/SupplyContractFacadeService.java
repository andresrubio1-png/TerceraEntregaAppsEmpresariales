package com.davidperez.proyectocomponenteselectronicosback.service;

import com.davidperez.proyectocomponenteselectronicosback.client.SupplyContractClient;
import com.davidperez.proyectocomponenteselectronicosback.dto.SupplyContract;
import com.davidperez.proyectocomponenteselectronicosback.dto.SupplyContractRequest;
import com.davidperez.proyectocomponenteselectronicosback.model.ContractStatus;
import com.davidperez.proyectocomponenteselectronicosback.model.Manufacturer;
import com.davidperez.proyectocomponenteselectronicosback.repository.ManufacturerRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import java.util.*;

@Service
public class SupplyContractFacadeService implements ISupplyContractFacadeService {

    @Autowired
    private SupplyContractClient client;

    @Autowired
    private ManufacturerRepository manufacturerRepository;

    @Override
    public SupplyContract create(SupplyContractRequest request) {
        validateManufacturerExists(request.getManufacturerId());
        return client.create(request);
    }

    @Override
    public List<SupplyContract> findAll(Integer manufacturerId,
                                           ContractStatus status,
                                           Double minValue,
                                           Double maxValue) {
        return client.findAll(manufacturerId, status, minValue, maxValue);
    }

    @Override
    public Optional<SupplyContract> findByContractNumber(String contractNumber) {
        return client.findByContractNumber(contractNumber);
    }

    @Override
    public Optional<SupplyContract> update(String contractNumber, SupplyContractRequest request) {
        validateManufacturerExists(request.getManufacturerId());
        return client.update(contractNumber, request);
    }

    @Override
    public boolean delete(String contractNumber) {
        return client.delete(contractNumber);
    }

    @Override
    public List<Map<String, Object>> findAllEnriched(Integer manufacturerId, ContractStatus status) {
        List<SupplyContract> contracts = client.findAll(manufacturerId, status, null, null);
        List<Map<String, Object>> result = new ArrayList<>();

        for (SupplyContract contract : contracts) {
            Map<String, Object> map = new LinkedHashMap<>();
            map.put("contractNumber",  contract.getContractNumber());
            map.put("totalValue",      contract.getTotalValue());
            map.put("durationMonths",  contract.getDurationMonths());
            map.put("status",          contract.getStatus());
            map.put("signedAt",        contract.getSignedAt());
            map.put("createdAt",       contract.getCreatedAt());
            map.put("manufacturerId",  contract.getManufacturerId());

            // Enriquecimiento con dos atributos del fabricante (Clase A)
            Optional<Manufacturer> mfr = manufacturerRepository.findById(contract.getManufacturerId());
            map.put("manufacturerName",    mfr.map(Manufacturer::getName).orElse(null));
            map.put("manufacturerCountry", mfr.map(Manufacturer::getCountry).orElse(null));

            result.add(map);
        }
        return result;
    }

    /**
     * Garantiza la integridad referencial: el fabricante debe existir
     * en la base de datos local antes de enviar el contrato al microservicio C.
     */
    private void validateManufacturerExists(Integer manufacturerId) {
        if (!manufacturerRepository.existsById(manufacturerId)) {
            throw new ResponseStatusException(
                    HttpStatus.BAD_REQUEST,
                    "Fabricante con id " + manufacturerId + " no encontrado");
        }
    }
}
