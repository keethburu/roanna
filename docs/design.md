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


# Pricing Policy 
Basic Policy: The foundational pricing rules applicable across all publishers and journals. It sets the base APCs and general discount or waiver rules.
Publisher-specific Policy: Overrides or extends the Basic Policy with additional rules specific to each publisher. These can include publisher-specific discounts, special waivers, or different base APC rates.
Journal-specific Policy: Further refines the pricing rules for individual journals under a publisher. It can override the Publisher-specific Policy with journal-specific rates or discounts.
Article/Transaction-specific Policy: The most granular level, allowing for custom pricing for individual articles or transactions. This can take into account article-specific factors like length, research field, open access status, etc.
# Data Model 
## PricingPolicy
PricingPolicyID: Unique identifier.
ParentPolicyID: Reference to the parent policy ID, allowing for inheritance.
PolicyType: Indicates the level (Basic, Publisher-specific, Journal-specific, Article-specific).
BasePrice: Base APC (can be inherited or overridden).
DiscountRules: Rules for discounts (can be inherited or overridden).
SpecialConditions: Special conditions (can be inherited or overridden).
## Publisher
PublisherID: Unique identifier.
PricingPolicyID: Reference to its specific pricing policy.
## Journal
JournalID: Unique identifier.
PublisherID: Reference to the publisher.
PricingPolicyID: Reference to its specific pricing policy.
## Article
ArticleID: Unique identifier.
JournalID: Reference to the journal.
PricingPolicyID: Reference to a specific policy, if any overrides are needed at the article level.
Transaction
TransactionID: Unique identifier.
ArticleID: Linked to the corresponding article.
Amount: Amount charged, determined based on the applicable pricing policy.

# Process Flow
## Policy Determination:
Start at the most specific level (Article-specific) and check if a policy is defined.
If not, move up to the Journal-specific level, then Publisher-specific, and finally to the Basic Policy.
At each level, inherited rules are considered unless explicitly overridden.

## APC Calculation:
Based on the determined policy, calculate the APC using base prices, discount rules, and special conditions.

## Transaction Creation
A Transaction is created with the calculated APC for the article.
This hierarchical model enables nuanced control over pricing policies at different levels, allowing each tier to customize or extend the rules of its parent. It's important to implement a robust logic mechanism to handle the inheritance and overriding of rules effectively. This approach can significantly enhance the platform's capability to cater to a diverse range of pricing scenarios.


# Csharp POCO
```csharp
public class Article
{
    public int ArticleID { get; set; }
    public string Title { get; set; }
    public string Abstract { get; set; }
    public int AuthorID { get; set; } // Assuming Author is another entity
    public int JournalID { get; set; }
    public DateTime PublicationDate { get; set; }
    public DateTime SubmissionDate { get; set; }
    public string Status { get; set; }
    public string DOI { get; set; }
    public string Keywords { get; set; }
    public string PeerReviewStatus { get; set; }
    // Navigation property
    public Journal Journal { get; set; }
}

public class Publisher
{
    public int PublisherID { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
    public int PricingPolicyID { get; set; }
    // Navigation property
    public PricingPolicy PricingPolicy { get; set; }
}

public class Journal
{
    public int JournalID { get; set; }
    public int PublisherID { get; set; }
    public string Name { get; set; }
    public int PricingPolicyID { get; set; }
    // Navigation properties
    public Publisher Publisher { get; set; }
    public PricingPolicy PricingPolicy { get; set; }
}

public class PricingPolicy
{
    public int PricingPolicyID { get; set; }
    public int? ParentPolicyID { get; set; } // Nullable for top-level policy
    public string PolicyType { get; set; } // Basic, Publisher-specific, etc.
    public decimal BasePrice { get; set; }
    public string DiscountRules { get; set; } // This could be a JSON string or a complex object
    public string SpecialConditions { get; set; } // Same as DiscountRules
}

public class Transaction
{
    public int TransactionID { get; set; }
    public int ArticleID { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime TransactionDate { get; set; }
    public string PaymentMethod { get; set; }
    public string Status { get; set; }
    public string InvoiceNumber { get; set; }
    public int PayerID { get; set; } // Assuming Payer is another entity
    // Navigation property
    public Article Article { get; set; }
}
```
