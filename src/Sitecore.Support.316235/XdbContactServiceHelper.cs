namespace Sitecore.Support.Cintel.Utility
{
  using System;
  using XConnect.Client;
  using XConnect.Client.Configuration;
  using XConnect.Collection.Model;
  using System.Collections.Generic;
  using Sitecore.XConnect;
  using Sitecore.Cintel.ContactService;
  using Sitecore.XConnect.Operations;

  internal class XdbContactServiceHelper
  {
    /// <summary>
    /// Returns the specified contact
    /// </summary>
    /// <param name="contactId"></param>
    /// <returns></returns>
    /// <exception cref="ContactNotFoundException">Thrown if contact not found</exception>
    internal static Contact GetContact(Guid contactId)
    {
      return GetContact(contactId, null);
    }

    internal static Contact GetContactByOptions(Guid contactId, ExpandOptions options = null)
    {
      using (XConnectClient client = SitecoreXConnectClientConfiguration.GetClient())
      {
        if (options == null)
        {
          options = new ContactExpandOptions()
          {
            Interactions = new RelatedInteractionsExpandOptions(IpInfo.DefaultFacetKey, WebVisit.DefaultFacetKey)
          };
        }
        var reference = new ContactReference(contactId);

        Contact contact = client.Get(reference, options);


        if (contact == null)
        {
          throw new Sitecore.Cintel.ContactService.ContactNotFoundException(string.Format("No Contact with id [{0}] found", contactId));
        }
        return contact;
      }

    }

    internal static Contact GetContact(Guid contactId, string[] facets)
    {
      using (XConnectClient client = SitecoreXConnectClientConfiguration.GetClient())
      {

        var reference = new ContactReference(contactId);

        Contact contact;
        if (facets != null && facets.Length > 0)
        {
          contact = client.Get(reference, new ContactExpandOptions(facets));
        }
        else
        {
          contact = client.Get(reference, new ContactExpandOptions());
        }

        if (contact == null)
        {
          throw new ContactNotFoundException(string.Format("No Contact with id [{0}] found", contactId));
        }
        return contact;
      }
    }

    internal static Interaction GetInteraction(Guid contactId, Guid interactionId, string[] facets = null)
    {
      using (XConnectClient client = SitecoreXConnectClientConfiguration.GetClient())
      {

        var contactReference = new ContactReference(contactId);
        var interactionRef = new InteractionReference(contactReference, interactionId);
        Interaction interaction;
        if (facets != null && facets.Length > 0)
        {
          interaction = client.Get(interactionRef, new ExpandOptions(facets));
        }
        else
        {
          interaction = client.Get(interactionRef, new ExpandOptions());
        }

        if (interaction == null)
        {
          throw new Exception(string.Format("No Interaction with id [{0}] found for contact id {1}", interactionId, contactId));
        }
        return interaction;
      }
    }

    internal static IReadOnlyCollection<IEntityLookupResult<Interaction>> GetInteractions(Guid contactId, List<Guid> interactionIdList, string[] facets = null)
    {
      using (XConnectClient client = SitecoreXConnectClientConfiguration.GetClient())
      {

        var interactionRef = new List<InteractionReference>();
        foreach (var curId in interactionIdList)
        {
          interactionRef.Add(new InteractionReference(contactId, curId));
        }

        IReadOnlyCollection<IEntityLookupResult<Interaction>> interactions;
        if (facets != null && facets.Length > 0)
        {
          interactions = client.Get(interactionRef, new ExpandOptions(facets));
        }
        else
        {
          interactions = client.Get(interactionRef, new ExpandOptions());
        }

        return interactions;
      }
    }

    /// <summary>
    /// Anonymoize a contact by deleting all identifiers (known and anonymous) and clears all facets or facet properties marked PII sensitive
    /// </summary>
    /// <param name="contactId"></param>
    /// <returns></returns>
    internal static bool Anonymize(Guid contactId)
    {
      using (XConnectClient client = SitecoreXConnectClientConfiguration.GetClient())
      {
        var reference = new ContactReference(contactId);
        Contact contact = client.Get(reference, new ContactExpandOptions());
        client.ExecuteRightToBeForgotten(contact);
        client.Submit();
      }
      return true;
    }
  }
}