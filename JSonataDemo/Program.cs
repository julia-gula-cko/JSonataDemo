﻿using System.Text.Json;
using Jsonata.Net.Native;
using Jsonata.Net.Native.Json;
using JSonataDemo;

// Events
string autoCaptured =
    "{\"payment_id\":\"pay_kh4zao4zewjupixtydgcrpqx3a\",\"action_id\":\"act_pjcgvwinugjefdmnzjlkeic55u\",\"merchant\":{\"id\":\"pc_mhqnbx3mavaejkr7bhnyqonkca\",\"name\":\"DisputesQAMBCMercha{\"payment_id\":\"pay_kh4zao4zewjupixtydgcrpqx3a\",\"action_id\":\"act_w72w3dp7xl4e5h4deey6wirkj4\",\"correlation_id\":\"03a4329f-1190-4c77-96df-57d0dfc6d4c7\",\"amount\":79.0,\"balances\":{\"total_authorized\":79.0,\"total_voided\":0.0,\"available_to_void\":0.0,\"total_captured\":79.0,\"available_to_capture\":0.0,\"total_refunded\":0.0,\"available_to_refund\":79.0},\"response_code\":\"10000\",\"response_summary\":\"Approved\",\"processed_on\":\"2023-03-21T20:17:15.5371611Z\",\"is_cko_network_token\":false}";
string requested = "{\"payment_id\":\"pay_kh4zao4zewjupixtydgcrpqx3a\",\"action_id\":\"act_pjcgvwinugjefdmnzjlkeic55u\",\"merchant\":{\"id\":\"pc_mhqnbx3mavaejkr7bhnyqonkca\",\"name\":\"DisputesQAMBCMerchant\"},\"segments\":[\"CKO_Merchant:100001-CKO_Business:100001-CKO_Channel:100001\"],\"correlation_id\":\"03a4329f-1190-4c77-96df-57d0dfc6d4c7\",\"requested_on\":\"2023-03-21T20:17:15.0442746Z\",\"source\":{\"type\":\"card\",\"instrument_id\":\"src_mggbprdfidbu5nnrldvgizsdke\",\"fingerprint\":\"0BF8FD96B523DC3F22E200A094890048200A038FA8C87D461CC2FFC3854DD729\",\"fingerprint_historic\":\"B769519730273CB51112C9257F3E86354FC9C14F7031B89EA5041C5F44413B29\",\"vault_id\":\"4214f265-da1f-491e-a587-d8de4d4b3b35\",\"scheme\":\"VISA\",\"masked_number\":\"424242******4242\",\"expiry_month\":4,\"expiry_year\":2033,\"bin\":\"424242\",\"bin_max\":\"42424242\",\"card_category\":\"CONSUMER\",\"card_type\":\"CREDIT\",\"product_id\":\"F\",\"issuer_name\":\"STRIPEPAYMENTSUKLIMITED\",\"issuer_country_iso2_code\":\"GB\",\"product_type\":\"VisaClassic\",\"billing_address\":{},\"phone\":{},\"origin\":{\"type\":\"card\"},\"card_on_file\":false,\"cvv_present\":true},\"amount\":79.0,\"currency\":\"GBP\",\"capture\":true,\"payment_type\":\"Regular\",\"3ds\":true,\"three_ds_protocol_version\":\"2.0.1\",\"three_ds_allow_upgrade\":false,\"attempt_n3d\":true,\"reference\":\"DisputesVisaGWCAcceptanceTest\",\"shipping\":{\"address\":{},\"phone\":{}},\"requestor\":{\"authentication_type\":\"Introspection\",\"id\":\"ack_ad7ywtdisojuxdc2vsgzme3uje\",\"ip_address\":\"10.82.97.242\"},\"customer\":{\"id\":\"cus_kvjvdrt5r2yu5kpnjftugqexhq\",\"email\":\"test_qa@checkout.com\",\"is_new\":false},\"authorization_type\":\"Final\",\"cavv\":\"AgAAAAAAAIR8CQrXcIhbQAAAAAA=\",\"skip_risk_check\":false}";
string acquirerCaptured = "{\"payment_id\":\"pay_kh4zao4zewjupixtydgcrpqx3a\",\"action_id\":\"act_w72w3dp7xl4e5h4deey6wirkj4\",\"correlation_id\":\"03a4329f-1190-4c77-96df-57d0dfc6d4c7\",\"transaction_id\":\"b0126895-f048-445c-92e9-41c37d26a6c2\",\"amount\":79.0,\"acquirer_id\":\"cko-visa\",\"merchant_acquirer_id\":\"pr_nedbtvebf2oetjsp4umfo5mvma\",\"processed_on\":\"2023-03-21T20:17:15.531859Z\",\"processing_time\":17.5925,\"acquirer_response_code\":\"00\",\"acquirer_reference_id\":\"94415115478605000610524\",\"acquirer_authorization_code\":\"959797\",\"acquirer_transaction_id\":\"840665642309280420057\",\"global_acquirer_id\":\"cko-visa\",\"acquirer_country\":\"GB\",\"acquirer_bin\":\"123456\",\"internal_transaction_id\":762982134.0,\"merchant_category_code\":\"5967\",\"gateway_services_only\":false,\"processor_settings\":{\"bin\":\"402121\",\"acquirer_credential_id\":\"12345\"},\"is_final\":true}";
string acquirerAuthorized = "{\"payment_id\":\"pay_kh4zao4zewjupixtydgcrpqx3a\",\"action_id\":\"act_pjcgvwinugjefdmnzjlkeic55u\",\"correlation_id\":\"03a4329f-1190-4c77-96df-57d0dfc6d4c7\",\"transaction_id\":\"79fb925e-c4b1-411e-8e9d-23b9778c176e\",\"amount\":79.0,\"acquirer_id\":\"cko-visa\",\"merchant_acquirer_id\":\"pr_nedbtvebf2oetjsp4umfo5mvma\",\"processed_on\":\"2023-03-21T20:17:15.1862313Z\",\"processing_time\":18.3753,\"acquirer_response_code\":\"00\",\"acquirer_reference_id\":\"969513324154\",\"acquirer_authorization_code\":\"194954\",\"acquirer_transaction_id\":\"569852572253815562204\",\"global_acquirer_id\":\"cko-visa\",\"acquirer_country\":\"GB\",\"acquirer_bin\":\"123456\",\"scheme_transaction_id\":\"134687597390788\",\"internal_transaction_id\":763070830.0,\"avs_check\":\"G\",\"cvv_check\":\"M\",\"acceptor\":{\"scheme_merchant_id\":\"100001\",\"name\":\"QA-3DS2\",\"city\":\"London\",\"country\":\"GB\"},\"billing_descriptor\":{\"name\":\"qa_QA-3DS2\",\"city\":\"London\"},\"payment_account_reference\":\"V001767984136397220\",\"merchant_category_code\":\"5967\",\"gateway_services_only\":false,\"processing_data\":{\"acquirer_pos_information\":\"597\",\"avscvv_result_code\":\"M\",\"transaction_identifier\":\"489102411931341\",\"validation_code\":\"\",\"excluded_transaction_identifier_reason\":\"\",\"market_specific_authorization_data_indicator\":\"\",\"merchant_verification_value\":\"\",\"product_id\":\"F\",\"authorization_characteristics_indicator\":\"\",\"eci_reclassification_code\":\"\",\"request_eci\":\"07\"},\"processor_settings\":{\"bin\":\"402121\",\"acquirer_credential_id\":\"12345\"},\"aft\":false,\"acquirer_timing\":100}";

//Output
string chargeCaptured =
    "{\"ChargeId\":\"3b90f951-2599-4793-a2f3-c0cc28be17d8\",\"ActionId\":\"8d6df5b7-baff-4ef8-9f83-2131eb222a4f\",\"CorrelationId\":\"03a4329f-1190-4c77-96df-57d0dfc6d4c7\",\"Transaction\":{\"Id\":\"b0126895-f048-445c-92e9-41c37d26a6c2\",\"Value\":79.0,\"AcquirerId\":22,\"AcquirerCredentialId\":12345,\"ProcessedOn\":\"2023-03-21T20:17:15.531859Z\",\"ResponseCode\":\"10000\",\"ResponseSummary\":\"Approved\",\"ResponseDetails\":\"Approved\",\"AcquirerTransactionId\":\"840665642309280420057\",\"GlobalAcquirerId\":\"cko-visa\",\"AcquirerCountry\":\"GB\",\"AcquirerBin\":\"123456\",\"AcquirerReferenceNumber\":\"94415115478605000610524\",\"AcquirerResponseCode\":\"00\",\"AuthorisationCode\":\"959797\",\"ProcessingTime\":17.5925,\"AcquirerName\":\"Checkout VISA\",\"MerchantCategoryCode\":\"5967\",\"GatewayServicesOnly\":false,\"ProcessorSettings\":{\"bin\":\"402121\",\"acquirer_credential_id\":\"12345\"}},\"MerchantReference\":\"Disputes Visa GWC Acceptance Test\",\"AuthorisationProcessorSettings\":{\"bin\":\"402121\",\"acquirer_credential_id\":\"12345\"},\"IsCkoNetworkToken\":false,\"IsForceCaptured\":false}";

JsonataQuery query = new JsonataQuery("action_id");
string result = query.Eval("{\"payment_id\":\"pay_kh4zao4zewjupixtydgcrpqx3a\",\"action_id\":\"act_pjcgvwinugjefdmnzjlkeic55u\",\"merchant\":{\"id\":\"pc_mhqnbx3mavaejkr7bhnyqonkca\",\"name\":\"DisputesQAMBCMercha{\"payment_id\":\"pay_kh4zao4zewjupixtydgcrpqx3a\",\"action_id\":\"act_w72w3dp7xl4e5h4deey6wirkj4\",\"correlation_id\":\"03a4329f-1190-4c77-96df-57d0dfc6d4c7\",\"amount\":79.0,\"balances\":{\"total_authorized\":79.0,\"total_voided\":0.0,\"available_to_void\":0.0,\"total_captured\":79.0,\"available_to_capture\":0.0,\"total_refunded\":0.0,\"available_to_refund\":79.0},\"response_code\":\"10000\",\"response_summary\":\"Approved\",\"processed_on\":\"2023-03-21T20:17:15.5371611Z\",\"is_cko_network_token\":false}");
Console.WriteLine(result);