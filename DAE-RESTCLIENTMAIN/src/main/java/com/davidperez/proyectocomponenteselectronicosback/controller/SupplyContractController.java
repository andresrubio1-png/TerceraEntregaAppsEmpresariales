package com.davidperez.proyectocomponenteselectronicosback.controller;

import com.davidperez.proyectocomponenteselectronicosback.dto.SupplyContract;
import com.davidperez.proyectocomponenteselectronicosback.dto.SupplyContractRequest;
import com.davidperez.proyectocomponenteselectronicosback.model.ContractStatus;
import com.davidperez.proyectocomponenteselectronicosback.service.ISupplyContractFacadeService;
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
import java.util.Map;

/**
 * Controlador fachada: expone las operaciones del microservicio C de forma
 * transparente para los clientes GUI. Internamente delega al SupplyContractClient
 * que hace las llamadas HTTP, y valida que el fabricante exista localmente.
 */
@RestController
@RequestMapping("/contracts")
@CrossOrigin(origins = "*")
@Tag(name = "Supply Contracts (Proxy)", description = "Gestión de contratos (proxy hacia el microservicio C)")
public class SupplyContractController {

    @Autowired
    private ISupplyContractFacadeService facade;

    @Operation(summary = "Crear un contrato de suministro")
    @ApiResponses({
            @ApiResponse(responseCode = "201", description = "Contrato creado",
                    content = @Content(schema = @Schema(implementation = SupplyContract.class))),
            @ApiResponse(responseCode = "400", description = "Datos inválidos o fabricante no existe", content = @Content),
            @ApiResponse(responseCode = "409", description = "Ya existe un contrato con ese número", content = @Content)
    })
    @PostMapping
    public ResponseEntity<SupplyContract> create(@Valid @RequestBody SupplyContractRequest request) {
        return new ResponseEntity<>(facade.create(request), HttpStatus.CREATED);
    }

    @Operation(summary = "Listar contratos",
            description = "Lista todos los contratos. Filtros: manufacturerId, status o rango de valor total.")
    @GetMapping
    public ResponseEntity<List<SupplyContract>> findAll(
            @Parameter(description = "Filtrar por id del fabricante") @RequestParam(required = false) Integer manufacturerId,
            @Parameter(description = "Filtrar por estado del contrato")  @RequestParam(required = false) ContractStatus status,
            @Parameter(description = "Valor mínimo del contrato")        @RequestParam(required = false) Double minValue,
            @Parameter(description = "Valor máximo del contrato")        @RequestParam(required = false) Double maxValue) {
        return ResponseEntity.ok(facade.findAll(manufacturerId, status, minValue, maxValue));
    }

    /**
     * Cumple la rúbrica: "Listar todos los objetos en la Clase C y dos de la Clase A a través de una grilla".
     * Devuelve cada contrato más nombre y país del fabricante asociado.
     */
    @Operation(summary = "Listar contratos enriquecidos con datos del fabricante",
            description = "Muestra todos los atributos del contrato + nombre y país del fabricante (2 atributos de Clase A)")
    @GetMapping("/enriched")
    public ResponseEntity<List<Map<String, Object>>> findAllEnriched(
            @Parameter(description = "Filtrar por id del fabricante") @RequestParam(required = false) Integer manufacturerId,
            @Parameter(description = "Filtrar por estado del contrato")  @RequestParam(required = false) ContractStatus status) {
        return ResponseEntity.ok(facade.findAllEnriched(manufacturerId, status));
    }

    @Operation(summary = "Buscar contrato por número")
    @ApiResponses({
            @ApiResponse(responseCode = "200", description = "Contrato encontrado",
                    content = @Content(schema = @Schema(implementation = SupplyContract.class))),
            @ApiResponse(responseCode = "404", description = "No encontrado", content = @Content)
    })
    @GetMapping("/{contractNumber}")
    public ResponseEntity<SupplyContract> findByContractNumber(@PathVariable String contractNumber) {
        return facade.findByContractNumber(contractNumber)
                .map(ResponseEntity::ok)
                .orElse(ResponseEntity.notFound().build());
    }

    @Operation(summary = "Actualizar contrato")
    @ApiResponses({
            @ApiResponse(responseCode = "200", description = "Actualizado",
                    content = @Content(schema = @Schema(implementation = SupplyContract.class))),
            @ApiResponse(responseCode = "404", description = "No encontrado", content = @Content),
            @ApiResponse(responseCode = "400", description = "Fabricante no existe", content = @Content)
    })
    @PutMapping("/{contractNumber}")
    public ResponseEntity<SupplyContract> update(@PathVariable String contractNumber,
                                                    @Valid @RequestBody SupplyContractRequest request) {
        return facade.update(contractNumber, request)
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
        if (facade.delete(contractNumber)) {
            return ResponseEntity.noContent().build();
        }
        return ResponseEntity.notFound().build();
    }
}
