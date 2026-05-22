package com.davidperez.supplycontractservice.controller;

import com.davidperez.supplycontractservice.dto.SupplyContractRequest;
import com.davidperez.supplycontractservice.model.ContractStatus;
import com.davidperez.supplycontractservice.model.SupplyContract;
import com.davidperez.supplycontractservice.service.ISupplyContractService;
import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.Parameter;
import io.swagger.v3.oas.annotations.media.Content;
import io.swagger.v3.oas.annotations.media.Schema;
import io.swagger.v3.oas.annotations.responses.ApiResponse;
import io.swagger.v3.oas.annotations.responses.ApiResponses;
import io.swagger.v3.oas.annotations.tags.Tag;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/contracts")
@CrossOrigin(origins = "*")
@Tag(name = "Supply Contracts", description = "Gestión de contratos de suministro con fabricantes")
public class SupplyContractController {

    @Autowired
    private ISupplyContractService service;

    @Operation(summary = "Crear un contrato de suministro")
    @ApiResponses({
            @ApiResponse(responseCode = "201", description = "Contrato creado",
                    content = @Content(schema = @Schema(implementation = SupplyContract.class))),
            @ApiResponse(responseCode = "400", description = "Datos inválidos", content = @Content),
            @ApiResponse(responseCode = "409", description = "Ya existe un contrato con ese número", content = @Content)
    })
    @PostMapping
    public ResponseEntity<SupplyContract> create(@Valid @RequestBody SupplyContractRequest request) {
        return new ResponseEntity<>(service.create(request), HttpStatus.CREATED);
    }

    @Operation(summary = "Listar contratos",
            description = "Retorna todos los contratos. Filtrar por manufacturerId, status o rango de valor total.")
    @GetMapping
    public ResponseEntity<List<SupplyContract>> findAll(
            @Parameter(description = "Filtrar por id del fabricante") @RequestParam(required = false) Integer manufacturerId,
            @Parameter(description = "Filtrar por estado del contrato") @RequestParam(required = false) ContractStatus status,
            @Parameter(description = "Valor mínimo del contrato") @RequestParam(required = false) Double minValue,
            @Parameter(description = "Valor máximo del contrato") @RequestParam(required = false) Double maxValue) {

        if (manufacturerId != null) {
            return ResponseEntity.ok(service.findByManufacturerId(manufacturerId));
        }
        if (status != null) {
            return ResponseEntity.ok(service.findByStatus(status));
        }
        if (minValue != null && maxValue != null) {
            return ResponseEntity.ok(service.findByTotalValueRange(minValue, maxValue));
        }
        return ResponseEntity.ok(service.findAll());
    }

    @Operation(summary = "Buscar contrato por número")
    @ApiResponses({
            @ApiResponse(responseCode = "200", description = "Contrato encontrado",
                    content = @Content(schema = @Schema(implementation = SupplyContract.class))),
            @ApiResponse(responseCode = "404", description = "No encontrado", content = @Content)
    })
    @GetMapping("/{contractNumber}")
    public ResponseEntity<SupplyContract> findByContractNumber(@PathVariable String contractNumber) {
        return service.findByContractNumber(contractNumber)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @Operation(summary = "Actualizar contrato")
    @ApiResponses({
            @ApiResponse(responseCode = "200", description = "Actualizado",
                    content = @Content(schema = @Schema(implementation = SupplyContract.class))),
            @ApiResponse(responseCode = "404", description = "No encontrado", content = @Content)
    })
    @PutMapping("/{contractNumber}")
    public ResponseEntity<SupplyContract> update(@PathVariable String contractNumber,
                                                 @Valid @RequestBody SupplyContractRequest request) {
        return service.update(contractNumber, request)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @Operation(summary = "Eliminar contrato")
    @ApiResponses({
            @ApiResponse(responseCode = "204", description = "Eliminado", content = @Content),
            @ApiResponse(responseCode = "404", description = "No encontrado", content = @Content)
    })
    @DeleteMapping("/{contractNumber}")
    public ResponseEntity<Void> delete(@PathVariable String contractNumber) {
        if (service.delete(contractNumber)) {
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
}
