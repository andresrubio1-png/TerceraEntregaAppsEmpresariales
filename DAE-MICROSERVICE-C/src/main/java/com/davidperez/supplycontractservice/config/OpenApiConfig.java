package com.davidperez.supplycontractservice.config;

import io.swagger.v3.oas.models.OpenAPI;
import io.swagger.v3.oas.models.info.Contact;
import io.swagger.v3.oas.models.info.Info;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class OpenApiConfig {

    @Bean
    public OpenAPI customOpenAPI() {
        return new OpenAPI()
                .info(new Info()
                        .title("Supply Contract API")
                        .version("1.0.0")
                        .description(
                                "API REST para la gestión de contratos de suministro asociados a fabricantes. " +
                                "Permite realizar operaciones CRUD sobre SupplyContract, con almacenamiento en " +
                                "una base de datos relacional Oracle independiente del microservicio principal.")
                        .contact(new Contact()
                                .name("DAE — Universidad de Ibagué")
                                .email("carlos.lugo@unibague.edu.co")));
    }
}
