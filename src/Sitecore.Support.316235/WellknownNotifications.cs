using Sitecore.Cintel.Commons;

namespace Sitecore.Cintel.Configuration
{
  /// <summary>
  /// Holds notification messages used in reports
  /// </summary>
  internal static class WellknownNotifications
  {
    internal static NotificationMessage CouldNotInstantiateMasterDataProvider
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 1758,
          MessageType = NotificationTypes.Warning,
          Text = Sitecore.Globalization.Translate.Text(WellknownTexts.CouldNotInstantiateMasterDataProvider)
        };
      }
    }

    internal static NotificationMessage EventsMasterDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 65,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOreMoreEventsDisplayNamesAreMissingFromTheMasterList)
        };
      }
    }

    internal static NotificationMessage GoalMasterDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 41,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOrMoreGoalsDataIsMissingFromTheMasterList)
        };
      }
    }

    internal static NotificationMessage CampaignMasterDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 42,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOreMoreCampaignDisplayNamesAreMissingFromTheMasterList)
        };
      }
    }

    internal static NotificationMessage MandatoryDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 13,
          MessageType = NotificationTypes.Error,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOrMoreDataEntriesAreMissingDueToInvalidData)
        };
      }
    }

    internal static NotificationMessage OptionalDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 314,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.SomeColumnsMayBeMissingData)
        };
      }
    }

    public static NotificationMessage PageEventMasterDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 400,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOreMorePageeventDefinitionItemsAreMissingFromTheMasterList)
        };
      }
    }

    public static NotificationMessage SearchColumnNonExisting
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 401,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOreMoreSearchCriterionsAreNonExisting)
        };
      }
    }

    public static NotificationMessage InvalidPagingParameters
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 410,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.PagingInformationWasInvalidThereforeTheValuesWereDefaulted)
        };
      }
    }

    public static NotificationMessage PageNumberOutOfBounds
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 411,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.TheSpecifiedPageNumberIsOutOfBounds)
        };
      }
    }

    internal static NotificationMessage EngagementPlanMasterDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 51,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOreMoreEngagamentPlanDisplayNamesAreMissingFromTheMasterList)
        };
      }
    }

    internal static NotificationMessage ChannelDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 71,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOrMoreChannelDataIsMissing)
        };
      }
    }

    internal static NotificationMessage ChannelNotSpecified
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 72,
          MessageType = NotificationTypes.Error,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.ChannelNotSpecifiedForInteraction)
        };
      }
    }


    internal static NotificationMessage OutcomeDefinitionDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 81,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOrMoreOutcomeDefinitionDataIsMissing)
        };
      }
    }

    internal static NotificationMessage OutcomeTypeDataMissing
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 82,
          MessageType = NotificationTypes.Warning,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OneOrMoreOutcomeTypeDataIsMissing)
        };
      }
    }

    internal static NotificationMessage InvalidViewParamter
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 83,
          MessageType = NotificationTypes.Error,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.InvalidViewParameter)
        };
      }
    }

    internal static NotificationMessage OutcomeIsNotFound
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 84,
          MessageType = NotificationTypes.Error,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.OutcomeIsNotFound)
        };
      }
    }

    internal static NotificationMessage OutcomeBelongsToDifferentOwner
    {
      get
      {
        return new NotificationMessage()
        {
          Id = 85,
          MessageType = NotificationTypes.Error,
          Text =
            Sitecore.Globalization.Translate.Text(
              WellknownTexts.RequestedOutcomeBelongsToDifferentOwner)
        };
      }
    }


  }
}