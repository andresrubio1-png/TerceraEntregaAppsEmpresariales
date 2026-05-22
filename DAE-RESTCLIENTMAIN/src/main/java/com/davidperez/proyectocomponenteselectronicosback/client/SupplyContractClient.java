package com.davidperez.proyectocomponenteselectronicosback.client;

import com.davidperez.proyectocomponenteselectronicosback.dto.SupplyContract;
import com.davidperez.proyectocomponenteselectronicosback.dto.SupplyContractRequest;
import com.davidperez.proyectocomponenteselectronicosback.model.ContractStatus;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpMethod;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.client.HttpClientErrorException;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Optional;

/**
 * Cliente HTTP que delega las operaciones de SupplyContract al microservicio C.
 * Encapsula RestTemplate para que el servicio fachada se mantenga limpio.
 */
@Component
public class SupplyContractClient {

    private final RestTemplate restTemplate;
    private final String baseUrl;

    public SupplyContractClient(RestTemplate restTemplate,
                                @Value("${microservice.c.url}") String baseUrl) {
        this.restTemplate = restTemplate;
        this.baseUrl = baseUrl;
    }

    public SupplyContract create(SupplyContractRequest request) {
        return restTemplate.postForObject(baseUrl + "/contracts", request, SupplyContract.class);
    }

    public List<SupplyContract> findAll(Integer manufacturerId,
                                           ContractStatus status,
                                           Double minValue,
                                           Double maxValue) {
        UriComponentsBuilder builder = UriComponentsBuilder.fromHttpUrl(baseUrl + "/contracts");
        if (manufacturerId != null) builder.queryParam("manufacturerId", manufacturerId);
        if (status != null)         builder.queryParam("status", status);
        if (minValue != null)       builder.queryParam("minValue", minValue);
        if (maxValue != null)       builder.queryParam("maxValue", maxValue);

        SupplyContract[] response = restTemplate.getForObject(
                builder.toUriString(), SupplyContract[].class);
        return response != null ? Arrays.asList(response) : Collections.emptyList();
    }

    public Optional<SupplyContract> findByContractNumber(String contractNumber) {
        try {
            SupplyContract body = restTemplate.getForObject(
                    baseUrl + "/contracts/" + contractNumber, SupplyContract.class);
            return Optional.ofNullable(body);
        } catch (HttpClientErrorException.NotFound e) {
            return Optional.empty();
        }
    }

    public Optional<SupplyContract> update(String contractNumber, SupplyContractRequest request) {
        try {
            HttpEntity<SupplyContractRequest> entity = new HttpEntity<>(request);
            ResponseEntity<SupplyContract> response = restTemplate.exchange(
                    baseUrl + "/contracts/" + contractNumber,
                    HttpMethod.PUT,
                    entity,
                    SupplyContract.class);
            return Optional.ofNullable(response.getBody());
        } catch (HttpClientErrorException.NotFound e) {
            return Optional.empty();
        }
    }

    public boolean delete(String contractNumber) {
        try {
            restTemplate.delete(baseUrl + "/contracts/" + contractNumber);
            return true;
        } catch (HttpClientErrorException.NotFound e) {
            return false;
        }
    }
}
