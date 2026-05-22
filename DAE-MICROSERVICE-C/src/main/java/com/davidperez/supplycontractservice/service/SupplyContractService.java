package com.davidperez.supplycontractservice.service;

import com.davidperez.supplycontractservice.dto.SupplyContractRequest;
import com.davidperez.supplycontractservice.model.ContractStatus;
import com.davidperez.supplycontractservice.model.SupplyContract;
import com.davidperez.supplycontractservice.repository.SupplyContractRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;
import java.util.Optional;

@Service
public class SupplyContractService implements ISupplyContractService {

    @Autowired
    private SupplyContractRepository repository;

    @Override
    public SupplyContract create(SupplyContractRequest request) {
        if (repository.existsById(request.getContractNumber())) {
            throw new ResponseStatusException(
                    HttpStatus.CONFLICT,
                    "Ya existe un contrato con el número " + request.getContractNumber());
        }
        SupplyContract sc = new SupplyContract();
        sc.setContractNumber(request.getContractNumber());
        sc.setTotalValue(request.getTotalValue());
        sc.setDurationMonths(request.getDurationMonths());
        sc.setStatus(request.getStatus());
        sc.setSignedAt(request.getSignedAt());
        sc.setManufacturerId(request.getManufacturerId());
        return repository.save(sc);
    }

    @Override
    public List<SupplyContract> findAll() {
        return repository.findAll();
    }

    @Override
    public Optional<SupplyContract> findByContractNumber(String contractNumber) {
        return repository.findById(contractNumber);
    }

    @Override
    public List<SupplyContract> findByManufacturerId(Integer manufacturerId) {
        return repository.findByManufacturerId(manufacturerId);
    }

    @Override
    public List<SupplyContract> findByStatus(ContractStatus status) {
        return repository.findByStatus(status);
    }

    @Override
    public List<SupplyContract> findByTotalValueRange(Double minValue, Double maxValue) {
        return repository.findByTotalValueBetween(minValue, maxValue);
    }

    @Override
    public Optional<SupplyContract> update(String contractNumber, SupplyContractRequest request) {
        return repository.findById(contractNumber).map(existing -> {
            existing.setTotalValue(request.getTotalValue());
            existing.setDurationMonths(request.getDurationMonths());
            existing.setStatus(request.getStatus());
            existing.setSignedAt(request.getSignedAt());
            existing.setManufacturerId(request.getManufacturerId());
            return repository.save(existing);
        });
    }

    @Override
    public boolean delete(String contractNumber) {
        if (repository.existsById(contractNumber)) {
            repository.deleteById(contractNumber);
            return true;
        }
        return false;
    }
}
