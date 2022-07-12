using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<MonsterTypeId, MonsterStaticData> _monsters;
    private Dictionary<string, LevelStaticData> _levels;

    public void LoadMonsters()
    {
      _monsters = Resources.LoadAll<MonsterStaticData>("StaticData/Monsters")
        .ToDictionary(x => x.MonsterType, x => x);
      _levels = Resources.LoadAll<LevelStaticData>("StaticData/Levels")
        .ToDictionary(x => x.LevelKey, x => x);
    }

    public MonsterStaticData ForMonster(MonsterTypeId monsterTypeId)
    {
      return _monsters.TryGetValue(monsterTypeId, out MonsterStaticData staticData)
        ? staticData
        : null;
    }

    public LevelStaticData ForLevel(string levelKey)
    {
      return _levels.TryGetValue(levelKey, out LevelStaticData levelData)
        ? levelData
        : null;
    }
  }
}