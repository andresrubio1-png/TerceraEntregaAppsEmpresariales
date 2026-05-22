package com.davidperez.proyectocomponenteselectronicosback.dto;

import com.davidperez.proyectocomponenteselectronicosback.model.ContractStatus;
import com.fasterxml.jackson.annotation.JsonInclude;
import io.swagger.v3.oas.annotations.media.Schema;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

/**
 * Representación de un SupplyContract devuelto por el microservicio C.
 * Sirve también como cuerpo de respuesta para los clientes GUI.
 * No es una entidad JPA: vive en este microservicio solo como objeto
 * de transporte que cruza la frontera HTTP hacia el microservicio C.
 */
@Data
@NoArgsConstructor
@AllArgsConstructor
@JsonInclude(JsonInclude.Include.NON_NULL)
@Schema(description = "Contrato de suministro (proxy desde microservicio C)")
public class SupplyContract {

    @Schema(description = "Identificador único del contrato", example = "CNT-2024-001")
    private String contractNumber;

    @Schema(description = "Valor total del contrato en USD", example = "150000.50")
    private Double totalValue;

    @Schema(description = "Duración del contrato en meses", example = "24")
    private Integer durationMonths;

    @Schema(description = "Estado del contrato", example = "ACTIVE")
    private ContractStatus status;

    @Schema(description = "Fecha y hora de firma", example = "2024-03-15T10:30:00")
    private LocalDateTime signedAt;

    @Schema(description = "Identificador del fabricante asociado", example = "1")
    private Integer manufacturerId;

    @Schema(description = "Fecha y hora de registro", accessMode = Schema.AccessMode.READ_ONLY)
    private LocalDateTime createdAt;
}
