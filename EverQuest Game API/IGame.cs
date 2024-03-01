using System;
using System.Data;
using System.ServiceModel;

namespace EverQuest_Game_API.Interface
{
    [ServiceContract]
    public interface IGame
    {
        #region Sport Management

        [OperationContract]
        DataSet GetSports(int sportID);

        [OperationContract]
        string SaveEditSport(DataSet dsSport);

        [OperationContract]
        DataSet GetAllSports();


        [OperationContract]
        DataSet GetAllSportsLeaguesAndGames(bool ActiveGamesOnly);

        [OperationContract]
        string DeleteTeamFromSport(int sportID, int teamID);

        #endregion

        #region League Management

        [OperationContract]
        DataSet GetAllLeagues();

        [OperationContract]
        DataSet GetLeagues(int leagueID, int sportID);

        [OperationContract]
        DataSet GetLeaguesBySportID(int sportID);

        [OperationContract]
        string SaveEditLeague(DataSet dsLeague);

        [OperationContract]
        string SaveLeagueGames(DataSet dsGames);

        [OperationContract]
        string SaveLeagueTeams(DataSet dsLeagueTeams);

        [OperationContract]
        DataSet GetLeagueGamesByLeagueId(int leagueId);

        [OperationContract]
        DataSet GetTeamsByLeagueID(int leagueId);

        [OperationContract]
        string RemoveTeamFromLeague(int leagueID, int teamID);

        #endregion

        #region Game Management

        [OperationContract]
        DataSet GetGameInfoForUSerByGameID(int gameId, int userid);

        [OperationContract]
        DataSet GetAllGames();

        [OperationContract]
        DataSet GetGameInfoOnlyByGameID(int gameId);

        [OperationContract]
        string SaveGameParticipants(DataSet dsGameParticipants, bool deductAmount, decimal gameAmount);

        [OperationContract]
        DataSet GetGameParticipants(int gameId);

        [OperationContract]
        DataSet GetPlayerDashboardFeeds(int userID);

        [OperationContract]
        DataSet GetPlayerDashboardArchives(DateTime? startDate, DateTime? endDate, int userID);

        [OperationContract]
        DataSet GetCurrentGamesList(int userID);

        [OperationContract]
        DataSet GetPendingGamesList(int userID);

        [OperationContract]
        DataSet GetUnsuccessfulGameJoinList(DateTime? startDate, DateTime? endDate, bool isArchived, int userID);

        [OperationContract]
        DataSet GetOldGamesList(DateTime? startDate, DateTime? endDate, bool isArchived, int userID);

        [OperationContract]
        string ArchiveOldGameForVQPlayer(int vqPlayerID, int userID);

        [OperationContract]
        string ArchiveUnsuccessfulGameJoinForVQPlayer(int gameParticipantID, int userID);

        [OperationContract]
        DataSet GetMatchTeamsInfoForResultEntering(int roundID);

        [OperationContract]
        DataSet GetPlayerTeamSelectionForRoundsByVQGameID(int vqGameID, int userID);

        [OperationContract]
        DataSet GetGameStatistics(int gameID);

        #endregion

        #region Team Management

        [OperationContract]
        DataSet GetTeamByID(int teamID);

        [OperationContract]
        string SaveNewTeam(DataSet dsNewTeam);

        [OperationContract]
        string UpdateTeam(DataSet dsTeam);

        [OperationContract]
        DataSet GetTeamList();

        [OperationContract]
        DataSet GetTeamListBySportID(int sportID);

        [OperationContract]
        DataSet GetExcludedTeamListForLeague(int sportID, int leagueID);

        [OperationContract]
        DataSet GetLeagueTeams(int leagueID);

        #endregion

        #region Tipping related

        [OperationContract]
        DataSet GetUserMatchesByRound(int vqGameID, int roundID, int userID);

        [OperationContract]
        DataSet GetTippingsForVQGame(int vqGameID, int vqPlayerID, int userID);

        [OperationContract]
        DataSet GetAvailableTippingsForUser(int vqGameID, int vqPlayerID, int userID); // TO BE REMOVED.....................

        [OperationContract]
        DataSet GetGameRoundDetailsForTipping(int vqGameID, int vqPlayer, int userID);

        [OperationContract]
        DataSet GetVQPlayerTippingsForVQGame(int vqGameID, int userID);

        [OperationContract]
        string SaveVQPlayerTippings(DataSet dsVQPlayerTippings);

        [OperationContract]
        string SavePlayerTippingForTeam(int gameID, int vqGameID, int vqPlayerID, int roundID, int matchID, int teamID, int userID); // TO BE REMOVED...................

        [OperationContract]
        string SavePlayerTippingForInitialTeamSelectionOnly(int gameID, int roundID, int matchID, int teamID, int userID, int gameParticipantID);

        [OperationContract]
        DataSet GetGameDetailsForInitialTipping(int gameID);

        [OperationContract]
        DataSet GetGameDetailsForInitialTippingInEditMode(int gameID, int gameParticipantID);

        [OperationContract]
        DataSet GetMatchesForFirstRound(int gameID, int roundID, int userID, int gameParticipantID);

        #endregion

        #region Round Management

        [OperationContract]
        string SaveMatch(DataSet dsMatches);

        [OperationContract]
        string SaveMatchInResultsEntering(DataSet dsMatches);


        [OperationContract]
        DataSet GetRoundsByLeagueID(int leagueID);


        #endregion

        #region Team Management

        [OperationContract]
        string SaveRound(DataSet dsMatches, int editingRoundID);

        [OperationContract]
        DataSet GetMatchesByRoundID(int roundID);

        #endregion

        #region Match Management

        [OperationContract]
        DataSet GetMatchesByMatchID(int matchID);

        #endregion

        #region MatchTeam Management

        [OperationContract]
        DataSet GetMatchTeamsByMatchID(int matchID);

        [OperationContract]
        DataSet GetMatchTeamsByRoundID(int roundID);

        [OperationContract]
        bool SaveMatchTeams(DataSet matchTeams, int roundID);

        [OperationContract]
        bool SaveMatchResults(int matchTeamID, bool winningStatus, int roundID);

        [OperationContract]
        bool FinalizeMatchResults(int roundID, int userID);


        [OperationContract]
        DataSet GetMatchStatusByMatchID(int matchID);

        [OperationContract]
        DataSet GetMatchStatusesForEnterResults(string codeHeaderName);

        #endregion

        #region Support
        [OperationContract]
        DataSet GetCodeValuesForCodeHeaderName(string codeHeaderName);

        [OperationContract]
        DataSet GetDocumentByDocumentMediaID(int documentMediaID);

        [OperationContract]
        DataSet GetDocumentByRelatedtablenameAndRelatedID(string relatedTableName, int relatedID);

        #endregion
    }
}
