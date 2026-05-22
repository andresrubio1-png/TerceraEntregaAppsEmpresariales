package com.davidperez.supplycontractservice.model;

import io.swagger.v3.oas.annotations.media.Schema;
import jakarta.persistence.*;
import jakarta.validation.constraints.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Entity
@Table(name = "SUPPLYCONTRACT")
@Data
@NoArgsConstructor
@AllArgsConstructor
@Schema(description = "Contrato de suministro firmado con un fabricante")
public class SupplyContract {

    @Id
    @Column(name = "CONTRACT_NUMBER", length = 20)
    @NotBlank(message = "El número de contrato no puede estar vacío")
    @Size(min = 3, max = 20, message = "El número de contrato debe tener entre 3 y 20 caracteres")
    @Pattern(regexp = "^[A-Z0-9-]+$", message = "El número de contrato solo permite mayúsculas, dígitos y guiones")
    @Schema(description = "Identificador único del contrato (clave primaria)", example = "CNT-2024-001")
    private String contractNumber;

    @Column(name = "TOTAL_VALUE", nullable = false, columnDefinition = "NUMBER")
    @NotNull(message = "El valor total es obligatorio")
    @Positive(message = "El valor total debe ser mayor a 0")
    @DecimalMax(value = "9999999999.99", message = "El valor total excede el máximo permitido")
    @Schema(description = "Valor total del contrato en USD", example = "150000.50")
    private Double totalValue;

    @Column(name = "DURATION_MONTHS", nullable = false, columnDefinition = "NUMBER")
    @NotNull(message = "La duración en meses es obligatoria")
    @Positive(message = "La duración debe ser mayor a 0")
    @Max(value = 120, message = "La duración no puede superar 120 meses (10 años)")
    @Schema(description = "Duración del contrato en meses", example = "24")
    private Integer durationMonths;

    @Enumerated(EnumType.STRING)
    @Column(name = "STATUS", nullable = false, length = 20)
    @NotNull(message = "El estado es obligatorio")
    @Schema(description = "Estado del contrato: PENDING, ACTIVE, EXPIRED, CANCELLED", example = "ACTIVE")
    private ContractStatus status;

    @Column(name = "SIGNED_AT", nullable = false)
    @NotNull(message = "La fecha de firma es obligatoria")
    @PastOrPresent(message = "La fecha de firma no puede ser futura")
    @Schema(description = "Fecha y hora de firma del contrato", example = "2024-03-15T10:30:00")
    private LocalDateTime signedAt;

    @Column(name = "ID_MANUFACTURER", nullable = false, columnDefinition = "NUMBER")
    @NotNull(message = "El fabricante es obligatorio")
    @Positive(message = "El id del fabricante debe ser positivo")
    @Schema(description = "Identificador del fabricante asociado (FK lógica al microservicio A-B)", example = "1")
    private Integer manufacturerId;

    @Column(name = "CREATED_AT", nullable = false, updatable = false)
    @Schema(description = "Fecha y hora de registro en el sistema", accessMode = Schema.AccessMode.READ_ONLY)
    private LocalDateTime createdAt;

    @PrePersist
    public void prePersist() {
        this.createdAt = LocalDateTime.now();
    }
}
