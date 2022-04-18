using System.Collections.Generic;

namespace EasyTestAnyThing.MSClassNew.MonsterAndHeroGame.Models.Response
{
    public class FightingResponse
    {
        public IEnumerable<FightingRecord> FightingRecord { get; set; }
        public string Winner { get; set; }
    }
}