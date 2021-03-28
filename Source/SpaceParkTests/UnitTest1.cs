using System;
using Xunit;
using SpaceEngine;
using System.Collections.Generic;

namespace SpaceParkTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Luke Skywalker")]
        [InlineData("Leia Organa")]
        [InlineData("Darth Vader")]
        public void ValidateCharacter_CorrectInput_ExpectTrue(string input)
        {
            var character = API.ValidateCharacter(input);
            bool correctCharacterName = character.Result.Results[0].Name == input;
            Assert.True(correctCharacterName);
        }

        [Theory]
        [InlineData("Jonas Schmedtmann")]
        [InlineData("Spacejam george")]
        [InlineData("Darth Peter")]
        public void ValidateCharacter_IncorrectInput_ExpectFalse(string input)
        {
            var character = API.ValidateCharacter(input);
            bool containsCharacter = character.Result.Results.Count == 1;
            Assert.False(containsCharacter);
        }

        [Theory]
        [InlineData("https://swapi.dev/api/starships/12/", "X-wing")]
        [InlineData("https://swapi.dev/api/starships/17/", "Rebel transport")]
        [InlineData("https://swapi.dev/api/starships/13/", "TIE Advanced x1")]
        public void ValidateStarshipName_CorrectInpute_ExpectTrue(string input, string expected)
        {
            List<string> ships = new();
            ships.Add(input);

            var ship = API.ValidateStarship(ships);
            bool correctShipName = ship.Result[0].Name == expected;
            Assert.True(correctShipName);
        }

        [Theory]
        [InlineData("https://swapi.dev/api/starships/12/", "T-Wing")]
        [InlineData("https://swapi.dev/api/starships/17/", "QN48b")]
        [InlineData("https://swapi.dev/api/starships/13/", "XC 70")]
        public void ValidateStarshipName_CorrectInpute_ExpectFalse(string input, string expected)
        {
            List<string> ships = new();
            ships.Add(input);

            var ship = API.ValidateStarship(ships);
            bool correctShipName = ship.Result[0].Name == expected;
            Assert.False(correctShipName);
        }
    }
}
