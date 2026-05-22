package com.davidperez.proyectocomponenteselectronicosback.dto;

import com.davidperez.proyectocomponenteselectronicosback.model.ContractStatus;
import io.swagger.v3.oas.annotations.media.Schema;
import jakarta.validation.constraints.*;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Data
@NoArgsConstructor
@Schema(description = "Datos para crear o actualizar un contrato de suministro (vía proxy)")
public class SupplyContractRequest {

    @NotBlank(message = "El número de contrato no puede estar vacío")
    @Size(min = 3, max = 20, message = "El número de contrato debe tener entre 3 y 20 caracteres")
    @Pattern(regexp = "^[A-Z0-9-]+$", message = "El número de contrato solo permite mayúsculas, dígitos y guiones")
    @Schema(description = "Número único del contrato", example = "CNT-2024-001", requiredMode = Schema.RequiredMode.REQUIRED)
    private String contractNumber;

    @NotNull(message = "El valor total es obligatorio")
    @Positive(message = "El valor total debe ser mayor a 0")
    @DecimalMax(value = "9999999999.99", message = "El valor total excede el máximo permitido")
    @Schema(description = "Valor total del contrato en USD", example = "150000.50", requiredMode = Schema.RequiredMode.REQUIRED)
    private Double totalValue;

    @NotNull(message = "La duración en meses es obligatoria")
    @Positive(message = "La duración debe ser mayor a 0")
    @Max(value = 120, message = "La duración no puede superar 120 meses")
    @Schema(description = "Duración del contrato en meses", example = "24", requiredMode = Schema.RequiredMode.REQUIRED)
    private Integer durationMonths;

    @NotNull(message = "El estado es obligatorio")
    @Schema(description = "Estado del contrato: PENDING, ACTIVE, EXPIRED, CANCELLED", example = "ACTIVE", requiredMode = Schema.RequiredMode.REQUIRED)
    private ContractStatus status;

    @NotNull(message = "La fecha de firma es obligatoria")
    @PastOrPresent(message = "La fecha de firma no puede ser futura")
    @Schema(description = "Fecha y hora de firma del contrato", example = "2024-03-15T10:30:00", requiredMode = Schema.RequiredMode.REQUIRED)
    private LocalDateTime signedAt;

    @NotNull(message = "El fabricante es obligatorio")
    @Positive(message = "El id del fabricante debe ser positivo")
    @Schema(description = "Identificador del fabricante asociado", example = "1", requiredMode = Schema.RequiredMode.REQUIRED)
    private Integer manufacturerId;
}
