package com.davidperez.proyectocomponenteselectronicosback.service;

import com.davidperez.proyectocomponenteselectronicosback.dto.SupplyContract;
import com.davidperez.proyectocomponenteselectronicosback.dto.SupplyContractRequest;
import com.davidperez.proyectocomponenteselectronicosback.model.ContractStatus;

import java.util.List;
import java.util.Map;
import java.util.Optional;

/**
 * Fachada que orquesta las operaciones del microservicio C (contratos)
 * con datos locales del microservicio A-B (fabricantes).
 */
public interface ISupplyContractFacadeService {

    SupplyContract create(SupplyContractRequest request);

    List<SupplyContract> findAll(Integer manufacturerId,
                                    ContractStatus status,
                                    Double minValue,
                                    Double maxValue);

    Optional<SupplyContract> findByContractNumber(String contractNumber);

    Optional<SupplyContract> update(String contractNumber, SupplyContractRequest request);

    boolean delete(String contractNumber);

    /**
     * Listado enriquecido: contratos + nombre y país del fabricante.
     */
    List<Map<String, Object>> findAllEnriched(Integer manufacturerId, ContractStatus status);
}
