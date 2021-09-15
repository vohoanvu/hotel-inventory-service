# hotel-inventory-service

The following document describes the requirement specifications for an OTA Inventory Sourcing Application. This small personal project serves as an educational exercise/mock project to learn .NET Core Web Api, that is also solving a real-world problem.

 

Objective:
One Centricity(OC) is an OTA website, built with Shopify, that connects customers within self-care life-style community to travel destinations, health and wellness providers in California and Mexico. 

One Centricity is currently having a problem with their supply of hotel inventories in southern California and Mexican border areas. They basically don’t have enough properties listings over there that are also aligned with their brand mission. They decided to make use of bed bank APIs provided by 3rd party company named HotelBeds, which is a wholesaler business that purchases rooms from accommodation providers in a bulk at a discounted price for specific dates and sells them to OTAs, travel agents, airlines, or tour operators. 

As a result, I’ve been hired as freelance developer to help OC develop a web application that can automatically source product/inventories from hotelBeds API, and then import them into One Centricity product catalog, all in real time, using Shopify Admin API.

Success metrics:
The ultimate goal here is to programmatically import inventory data, including static and dynamic content, into One Centricity product database. 

- Goal: Fill up OC hotel inventory

- Metric: There are at least 1000 products/services in OC coming from hotelBeds



Assumptions:

- Merchant will only see the hotel listing data being displayed inside Shopify Admin console.

- There are no graphical user interface needed to trigger the import of hotel data.

- The execution of exporting and importing process will be represented as a set of .NET 5 web services (.NET Core Web API)

- HotelBeds REST API documentation is provided here (Home )

- HotelBeds provides 3 suites of API (Hotels, Activities, Transfers). In the scope of this project, the developer will use Hotels APIs suite.

- In order to send request, developer needs to get api key, secret, and X-Signature from my hotelBeds account. X-Signature value will be calculated from api key and secret, using the provided script.

- The API key provided will only give me access to hotelBeds' test environment, with a limited allowed quota of 50 requests per day.

- Inside Hotels API suite, there are 3 types: BookingAPI (covering the complete booking process), ContentAPI (returning static information needed for BookingAPI), CacheAPI (saving data in zip files and return them upon request). The data saved in Shopify should be a combination of these 3 response results. However, for the scope of this project, developer can use only ContentAPI and BookingAPI.

- ContentAPI cannot be used to retrieve static information in real-time. This could result in the blocking of credentials. HotelBeds recommends that users should set up a batch process to retrieve the info from them on a periodic basis, and a database on their side to store the retrieved information and be able to use it when needed.

- Shopify provides access to REST Admin API and GraphQL Admin API, which can be used to access the store inventory information. For the scope of this project, we will use GraphQL Admin API because it support bulk product operations. Documentation is provided here (https://shopify.dev/api/admin )

- Shopify Admin API enforces rate limits on all request, so responsible API calls in the code should be taken into consideration. (https://shopify.dev/api/usage/rate-limits )

- For now, OC should only contain hotel listings from the following destinations in USA: San Diego, Los Angeles, San Francisco, Joshua Trees, Big Sur, Malibu, Santa Barbara
- For now, OC should only contain hotel listings from the following destinations in Mexico: Cancun, Holbox, Tulum, Puerto Vallanta, Sayulita, Nayrit, Baja Ca, Puerto To Escodido, Oxcaca, San Migule, Mexico City, Rivera Maya


 
