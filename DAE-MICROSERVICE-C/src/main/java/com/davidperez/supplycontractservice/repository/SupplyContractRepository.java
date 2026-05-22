package com.davidperez.supplycontractservice.repository;

import com.davidperez.supplycontractservice.model.ContractStatus;
import com.davidperez.supplycontractservice.model.SupplyContract;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface SupplyContractRepository extends JpaRepository<SupplyContract, String> {

    List<SupplyContract> findByManufacturerId(Integer manufacturerId);

    List<SupplyContract> findByStatus(ContractStatus status);

    List<SupplyContract> findByDurationMonthsBetween(Integer min, Integer max);

    /**
     * CONSULTA PERSONALIZADA:
     * Contratos cuyo valor total está dentro de un rango dado, ordenados de mayor a menor.
     */
    @Query("""
        SELECT sc FROM SupplyContract sc
        WHERE sc.totalValue BETWEEN :min AND :max
        ORDER BY sc.totalValue DESC
    """)
    List<SupplyContract> findByTotalValueBetween(@Param("min") Double min, @Param("max") Double max);
}
