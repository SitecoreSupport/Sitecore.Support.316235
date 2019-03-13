namespace Sitecore.Support.Cintel.Reporting.Contact.ProfileKeyScore.Processors
{
  using System;
  using System.Data;
  using System.Linq;
  using Sitecore.Analytics;
  using Sitecore.Analytics.Data.Items;
  using Sitecore.Cintel.Configuration;
  using Sitecore.Cintel.Reporting.Processors;
  using Sitecore.Cintel.Reporting.ReportingServerDatasource;
  using Sitecore.Cintel.Reporting.Utility;
  using Sitecore.Cintel.Utility;
  using Sitecore.XConnect.Collection.Model;
  using Sitecore.Cintel.Reporting.Contact.ProfileKeyScore;
  using Sitecore.Cintel.Reporting;

  public class PopulateProfileKeyScoresWithXdbData : ReportProcessorBase
  {
    #region Public methods

    public override void Process(ReportProcessorArgs reportArguments)
    {
      DataTable rawTable = reportArguments.QueryResult;

      DataTable resultTable = reportArguments.ResultTableForView;

      this.ProjectRawTableIntoResultTable(reportArguments, rawTable, resultTable);

      reportArguments.ResultSet.Data.Dataset[reportArguments.ReportParameters.ViewName] = resultTable;
    }

    #endregion

    #region Private methods

    private bool ProjectOneProfileKey(DataTable resultTable, DataRow sourceRow, double total)
    {
      Guid profileId = sourceRow.Field<Guid>(Schema.ProfileId.Name);
      ProfileItem profile = Tracker.DefinitionItems.Profiles[profileId];

      DataRow resultRow = resultTable.NewRow();

      bool fillWasSuccesful = this.TryFillData(resultRow, Schema.ContactId, sourceRow, XConnectFields.Interaction.ContactId)
                              && this.TryFillData(resultRow, Schema.LatestVisitId, sourceRow, XConnectFields.Interaction.Id)
                              && this.TryFillData(resultRow, Schema.ProfileId, sourceRow, XConnectFields.Profile.ProfileId)
                              && this.TryFillData(resultRow, Schema.ProfileKeyId, sourceRow, XConnectFields.Profile.ProfileKeyId);


      var calculatedScore = (Double)sourceRow[XConnectFields.Profile.Score];

      #region Modified code
      var interaction = Sitecore.Support.Cintel.Utility.XdbContactServiceHelper.GetInteraction(sourceRow.Field<Guid>(XConnectFields.Interaction.ContactId), sourceRow.Field<Guid>(XConnectFields.Interaction.Id), new string[] { "ProfileScores" });
      ProfileScores facet = interaction.GetFacet<ProfileScores>(ProfileScores.DefaultFacetKey);
      var count = (Double)facet.Scores[sourceRow.Field<Guid>(XConnectFields.Profile.ProfileId)].ScoreCount;
      #endregion

      if (profile.Type.ToLower() == "average")
      {
        calculatedScore = Calculator.GetAverageValue(calculatedScore, count);
      }
      else if (profile.Type.ToLower() == "percentage")
      {
        calculatedScore = total == 0 ? calculatedScore : (calculatedScore / total);
      }

      resultRow[Schema.ProfileKeyValue.Name] = Math.Round(calculatedScore, 2);

      if (!fillWasSuccesful)
      {
        return false;
      }

      resultTable.Rows.Add(resultRow);
      return true;
    }

    private void ProjectRawTableIntoResultTable(ReportProcessorArgs reportArguments, DataTable rawTable, DataTable resultTable)
    {
      bool mandatoryDataMissing = false;

      // todo: this is a hack, consider adding the total earlier when the table is created.
      Double total = rawTable.AsEnumerable().Sum(r => r.Field<Double>("Score"));
      foreach (DataRow sourceRow in rawTable.AsEnumerable())
      {
        mandatoryDataMissing = !this.ProjectOneProfileKey(resultTable, sourceRow, total);
      }

      if (mandatoryDataMissing)
      {
        LogNotificationForView(reportArguments.ReportParameters.ViewName, Sitecore.Support.Cintel.Configuration.WellknownNotifications.MandatoryDataMissing);
      }
    }

    #endregion
  }
}