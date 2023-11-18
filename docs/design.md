# Intro
This describes the approach of creating an open-source alternative solution for managing Article Processing Charges (APC) and Open Access (OA)
Alternative to services like
* https://www.aptaracorp.com/solutions/publishing/scipristm-open-access/ 
* https://www.copyright.com/solutions-rightslink-scientific-communications/
A a flexible, scalable, and secure platform for APC and OA management. The emphasis is on leveraging existing technologies and cloud services to avoid reinventing the wheel and facilitate rapid development and deployment. 

# Core Feature Set
## APC Management
Automated handling of APCs, including invoicing, payment tracking, and reconciliation.
## Metadata Capture and Integration
Ability to integrate with peer review and production systems to capture necessary metadata.
## User Identification and Authentication
Integration with 3rd party auth providers like ORCID, Google, etc., for user verification and tracking.
## Integration in Public Research Information Infrastructure
### Support PIDs
GRID, ROR, Ringgold, FundRef, ISNI
### Information Exchange
OA-Switchboard, Crossref, DataCite ect
## Publisher-Specific Business Rules
Customizable rules for discounts, waivers, and tiered pricing.
## Institutional Account Management
Features to manage institutional accounts, including credits, debits, tokens, and promo codes. Integratin with OA Switchboard
## Multi-Currency and Tax Handling
Capabilities to handle multiple currencies and automate tax calculations. (Based on integrated 3rd party services)
## Payment Processing
Integration with PCI-compliant payment gateways to support various payment methods.
Reporting and Analytics: Customizable reporting tools for publishers, authors, and institutions/funders.

# App Domain Model Entities
## Author/User
Represents individuals submitting articles, with properties for identification and authentication.
## Publisher
Entities that manage journals and handle APCs.
## Institution/Funder
Entities responsible for funding authors or managing institutional accounts.
## Article
Represents submitted articles, including metadata related to peer review and publication.
## Transaction
Captures details of APC payments, including amounts, currency, and payment method.

# Core MVP Features (Version 0.1.0)
The MVP should serve as a proof of concept that demonstrates the platform's potential value in simplifying and automating the APC and OA management process. It’s important to balance simplicity with functionality, ensuring that the MVP addresses the core pain points of the target user base while leaving room for future enhancements based on user feedback and technological advancements.

## Basic APC Management
Enable automated handling of APCs with basic features for invoicing and payment tracking.
Limit to the most common payment methods initially, such as credit card and wire transfer.

## Metadata Capture and Integration
Integrate with a limited number of peer review and production systems to capture essential metadata.
Prioritize integration with widely-used systems or those that offer the simplest integration paths.
Janeway and OJS?

## User Identification and Authentication
Implement basic user authentication, possibly using popular third-party providers like ORCID and Google.
Ensure secure login and user data protection.

## Simple Publisher-Specific Business Rules
Allow for basic customization of discounts and waivers.
Implement a simplified version of tiered pricing.

## Basic Institutional Account Management
Facilitate the management of institutional accounts with fundamental features like credits and debits.
Introduce a simple token system if feasible within the MVP timeframe.

## Payment Processing:
Integrate with a single, well-established PCI-compliant payment gateway.
Ensure secure transaction processing.

## Reporting and Analytics:
Provide basic reporting tools for publishers and authors.
Focus on essential data that provides immediate value, like payment status and article submission metrics.


# Non-MVP Features (For Future Development)
* Advanced metadata integration and handling.
* Comprehensive institutional account management features.
* Multi-currency and tax handling.
* Full integration with various research information infrastructures.
* Advanced reporting and analytics for all user types.
* Expanded payment methods and gateways.
* Enhanced customer support interfaces (Jira?)

# Development and Deployment Considerations
## API-first


## Cloud-Based Infrastructure
scalable cloud platform to ensure easy expansion and updates post-MVP.
## Security and Compliance: 
Priority for data security and privacy to build trust with early users.

# Future Development Considerations
## Machine Learning and AI Integration
In future versions, the integration of AI for predictive analytics and to automate more complex tasks like advanced metadata handling.
Scalability Tests:
Plan for scalability testing as part of future development to ensure the platform can handle increased loads and user numbers effectively.
