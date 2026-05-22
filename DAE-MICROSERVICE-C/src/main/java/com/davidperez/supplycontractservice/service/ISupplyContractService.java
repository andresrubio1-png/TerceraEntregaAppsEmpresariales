package com.davidperez.supplycontractservice.service;

import com.davidperez.supplycontractservice.dto.SupplyContractRequest;
import com.davidperez.supplycontractservice.model.ContractStatus;
import com.davidperez.supplycontractservice.model.SupplyContract;

import java.util.List;
import java.util.Optional;

public interface ISupplyContractService {

    SupplyContract create(SupplyContractRequest request);

    List<SupplyContract> findAll();

    Optional<SupplyContract> findByContractNumber(String contractNumber);

    List<SupplyContract> findByManufacturerId(Integer manufacturerId);

    List<SupplyContract> findByStatus(ContractStatus status);

    List<SupplyContract> findByTotalValueRange(Double minValue, Double maxValue);

    Optional<SupplyContract> update(String contractNumber, SupplyContractRequest request);

    boolean delete(String contractNumber);
}
