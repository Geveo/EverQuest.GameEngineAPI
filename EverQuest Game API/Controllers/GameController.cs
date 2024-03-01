using EverQuest_Game_API.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace EverQuest_Game_API.Controllers
{
    [Route("api/games")]
    [ApiController]

    public class GameController : ControllerBase
    {
        [HttpGet]
        [Route("getAllSportsLeagesAndGames")]
        //Gets all sports and leagues
        public ActionResult GetAllSportsLeaguesAndGames(bool activeGames)
        {
            var serviceFactory = new ServiceFactory();
            try
            {
                DataSet ds = serviceFactory.Game.GetAllSportsLeaguesAndGames(activeGames);

                var sportsWithLeaguesAndGames = new List<object>();

                // Iterate through each row in the "Sports" table
                foreach (DataRow sportRow in ds.Tables["Sports"].Rows)
                {
                    int sportId = Convert.ToInt32(sportRow["SportID"]);
                    string sportName = Convert.ToString(sportRow["SportName"]);

                    // Filter the "Leagues" table for leagues associated with the current sport
                    DataView leaguesView = new DataView(ds.Tables["Leagues"]);
                    leaguesView.RowFilter = $"SportID = {sportId}";

                    // Check if there are any leagues associated with the current sport
                    if (leaguesView.Count > 0)
                    {
                        var leaguesWithGames = new List<object>();

                        // Iterate through each league associated with the current sport
                        foreach (DataRowView leagueRowView in leaguesView)
                        {
                            DataRow leagueRow = leagueRowView.Row;
                            int leagueId = Convert.ToInt32(leagueRow["LeagueID"]);

                            // Filter the "Games" table for games associated with the current league
                            DataView gamesView = new DataView(ds.Tables["Games"]);
                            gamesView.RowFilter = $"LeagueID = {leagueId}";

                            // Count the number of games associated with the current league
                            int numberOfGames = gamesView.Count;

                            // If there are games associated with the league, include it in the result
                            if (numberOfGames > 0)
                            {
                                var leagueWithGames = new
                                {
                                    LeagueID = leagueId,
                                    LeagueName = Convert.ToString(leagueRow["LeagueName"]),
                                    NumberOfGames = numberOfGames
                                };
                                leaguesWithGames.Add(leagueWithGames);
                            }
                        }

                        // If there are leagues with games associated with the sport, include the sport in the result
                        if (leaguesWithGames.Count > 0)
                        {
                            var sportWithLeaguesAndGames = new
                            {
                                SportID = sportId,
                                SportName = sportName,
                                Leagues = leaguesWithGames
                            };
                            sportsWithLeaguesAndGames.Add(sportWithLeaguesAndGames);
                        }
                    }
                }

                string jsonResult = JsonConvert.SerializeObject(sportsWithLeaguesAndGames, Formatting.Indented);
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getLeaguesBySportID")]
        //Get all leauges by Sports ID
        public ActionResult GetLeaguesBySportID(int sportID)
        {
            var serviceFactory = new ServiceFactory();
            try
            {
                DataSet ds = serviceFactory.Game.GetLeaguesBySportID(sportID);

                string jsonResult = JsonConvert.SerializeObject(ds, Formatting.Indented);
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet]
        [Route("getLeagueGamesByLeagueId")]
        //Get League details by league ID
        public ActionResult GetLeagueGamesByLeagueId(int leagueId)
        {
            var serviceFactory = new ServiceFactory();
            try
            {
                DataSet ds = serviceFactory.Game.GetLeagueGamesByLeagueId(leagueId);

                string jsonResult = JsonConvert.SerializeObject(ds, Formatting.Indented);
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getGameInfoByGameID")]
        //Get game details by game ID
        public ActionResult GetGameInfoByGameID(int gameId)
        {
            var serviceFactory = new ServiceFactory();
            try
            {
                DataSet ds = serviceFactory.Game.GetGameInfoOnlyByGameID(gameId);

                string jsonResult = JsonConvert.SerializeObject(ds, Formatting.Indented);
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
