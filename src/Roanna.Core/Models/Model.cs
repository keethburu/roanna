using System;
using System.Collections.Generic;

namespace Roanna.Core.Models;


/// <summary>
/// Represents an article submitted for publication.
/// </summary>
public class Article
{
    /// <summary>
    /// Unique identifier for the article.
    /// </summary>
    public int ArticleID { get; set; }

    /// <summary>
    /// Title of the article.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Abstract of the article.
    /// </summary>
    public string Abstract { get; set; }

    /// <summary>
    /// Identifier of the author who submitted the article.
    /// </summary>
    public int AuthorID { get; set; }

    /// <summary>
    /// Identifier of the journal in which the article is published.
    /// </summary>
    public int JournalID { get; set; }

    /// <summary>
    /// Date when the article was published.
    /// </summary>
    public DateTime PublicationDate { get; set; }

    /// <summary>
    /// Date when the article was submitted for publication.
    /// </summary>
    public DateTime SubmissionDate { get; set; }

    /// <summary>
    /// Current status of the article in the publication process.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Digital Object Identifier for the article.
    /// </summary>
    public string DOI { get; set; }

    /// <summary>
    /// Keywords associated with the article.
    /// </summary>
    public string Keywords { get; set; }

    /// <summary>
    /// Status of the article's publication.
    /// </summary>
    public string PublicationStatus { get; set; }

    /// <summary>
    /// The Journal in which the article is published.
    /// </summary>
    public Journal Journal { get; set; }
}


/// <summary>
/// Represents a publisher in the system.
/// </summary>
public class Publisher
{
    /// <summary>
    /// Unique identifier for the publisher.
    /// </summary>
    public int PublisherID { get; set; }

    /// <summary>
    /// Name of the publisher.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Contact information for the publisher.
    /// </summary>
    public string ContactInfo { get; set; }

    /// <summary>
    /// Physical address of the publisher.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Website URL of the publisher.
    /// </summary>
    public string Website { get; set; }

    /// <summary>
    /// Collection of journals associated with the publisher.
    /// </summary>
    /// <remarks>
    /// This is a navigation property that links the publisher to its journals.
    /// </remarks>
    public ICollection<Journal> Journals { get; set; }
}
/// <summary>
/// Represents a journal within the publishing system.
/// </summary>
public class Journal
{
    /// <summary>
    /// Unique identifier for the journal.
    /// </summary>
    public int JournalID { get; set; }

    /// <summary>
    /// Identifier of the publisher of the journal.
    /// </summary>
    public int PublisherID { get; set; }

    /// <summary>
    /// Name of the journal.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Identifier for the pricing policy associated with the journal.
    /// </summary>
    public int PricingPolicyID { get; set; }

    /// <summary>
    /// Publisher associated with the journal.
    /// </summary>
    public Publisher Publisher { get; set; }

    /// <summary>
    /// Pricing policy associated with the journal.
    /// </summary>
    public PricingPolicy PricingPolicy { get; set; }
}

/// <summary>
/// Defines the pricing policy for article processing charges.
/// </summary>
public class PricingPolicy
{
    /// <summary>
    /// Unique identifier for the pricing policy.
    /// </summary>
    public int PricingPolicyID { get; set; }

    /// <summary>
    /// Identifier for the parent policy, if applicable.
    /// </summary>
    public int? ParentPolicyID { get; set; } // Nullable for top-level policy

    /// <summary>
    /// Type of pricing policy.
    /// </summary>
    public string PolicyType { get; set; } // Basic, Publisher-specific, etc.

    /// <summary>
    /// Base price defined in the pricing policy.
    /// </summary>
    public decimal BasePrice { get; set; }

    /// <summary>
    /// Rules for discounts, expressed as a JSON string or a complex object.
    /// </summary>
    public string DiscountRules { get; set; }

    /// <summary>
    /// Special conditions that may apply, expressed similarly to discount rules.
    /// </summary>
    public string SpecialConditions { get; set; }
}

/// <summary>
/// Represents a financial transaction associated with an article.
/// </summary>
public class Transaction
{
    /// <summary>
    /// Unique identifier for the transaction.
    /// </summary>
    public int TransactionID { get; set; }

    /// <summary>
    /// Identifier of the associated article.
    /// </summary>
    public int ArticleID { get; set; }

    /// <summary>
    /// Amount involved in the transaction.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Currency of the transaction.
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Date when the transaction occurred.
    /// </summary>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Method used for the payment.
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// Current status of the transaction.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Invoice number associated with the transaction.
    /// </summary>
    public string InvoiceNumber { get; set; }

    /// <summary>
    /// Identifier for the institution involved in the transaction, if applicable.
    /// </summary>
    public int? InstitutionID { get; set; } // Nullable

    /// <summary>
    /// The associated article for the transaction.
    /// </summary>
    public Article Article { get; set; }

    /// <summary>
    /// The associated institution for the transaction, if any.
    /// </summary>
    public Institution Institution { get; set; } // Nullable
}

/// <summary>
/// Represents an agreement between a publisher and an institution.
/// </summary>
public class Agreement
{
    /// <summary>
    /// Unique identifier for the agreement.
    /// </summary>
    public int AgreementID { get; set; }

    /// <summary>
    /// Identifier of the publisher involved in the agreement.
    /// </summary>
    public int PublisherID { get; set; }

    /// <summary>
    /// Identifier of the institution involved in the agreement.
    /// </summary>
    public int InstitutionID { get; set; }

    /// <summary>
    /// Type of the agreement.
    /// </summary>
    public string AgreementType { get; set; } // "Ownership", "Publishing", etc.

    /// <summary>
    /// Start date of the agreement.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// End date of the agreement.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Details about the discounts provided in the agreement.
    /// </summary>
    public string DiscountDetails { get; set; }

    /// <summary>
    /// Publisher involved in the agreement.
    /// </summary>
    public Publisher Publisher { get; set; }

    /// <summary>
    /// Institution involved in the agreement.
    /// </summary>
    public Institution Institution { get; set; }

    /// <summary>
    /// Collection of journals eligible under the agreement.
    /// </summary>
    public ICollection<Journal> EligibleJournals { get; set; }
}

/// <summary>
/// Represents an academic or research institution in the system.
/// </summary>
public class Institution
{
    /// <summary>
    /// Unique identifier for the institution.
    /// </summary>
    public int InstitutionID { get; set; }

    /// <summary>
    /// Name of the institution.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Contact details for the institution.
    /// </summary>
    public string ContactDetails { get; set; }

    /// <summary>
    /// Type of the institution (e.g., Academic, Research, JournalOwner).
    /// </summary>
    public string InstitutionType { get; set; } // "Academic", "Research", "JournalOwner", etc.

    /// <summary>
    /// Collection of agreements the institution is part of.
    /// </summary>
    /// <remarks>
    /// This is a navigation property that links the institution to its agreements.
    /// </remarks>
    public ICollection<Agreement> Agreements { get; set; }
}

/// <summary>
/// Represents an author within the publishing system.
/// </summary>
public class Author
{
    /// <summary>
    /// Unique identifier for the author.
    /// </summary>
    public int AuthorID { get; set; }

    /// <summary>
    /// First name of the author.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Middle name of the author.
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// Last name of the author.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email address of the author.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Username for the author in the system (if applicable).
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// ORCID iD of the author, providing a unique identifier.
    /// </summary>
    public string ORCID { get; set; }

    /// <summary>
    /// Institution with which the author is affiliated.
    /// </summary>
    public string Institution { get; set; }

    /// <summary>
    /// Department within the institution where the author works.
    /// </summary>
    public string Department { get; set; }

    /// <summary>
    /// Brief biography of the author.
    /// </summary>
    public string Biography { get; set; }

    /// <summary>
    /// Collection of articles written by the author.
    /// </summary>
    /// <remarks>
    /// This is a navigation property that links the author to their articles.
    /// </remarks>
    public ICollection<Article> Articles { get; set; }
}






