using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


namespace SCCC
{
    public class StatManager : Singleton<StatManager>
    {
        public bool resetPlayerPrefs = false;

        private string _sidList = "";
        private Dictionary<string, int> _stats = new Dictionary<string, int>();

        protected override void Awake()
        {
            base.Awake();

            if (resetPlayerPrefs)
            {
                Debug.LogWarning("deleting all PlayPrefs");
                PlayerPrefs.DeleteAll();
            }
            else if (PlayerPrefs.HasKey("sidList"))
            {
                _sidList = PlayerPrefs.GetString("sidList");
                string[] sidListTokens = _sidList.Split(' ');

                foreach (var sid in sidListTokens)
                {
                    _stats[sid] = PlayerPrefs.GetInt(sid);
                    Debug.Log($"loaded persistent stat {sid} value {_stats[sid]}");
                }
            }
            else
            {
                Debug.LogWarning("no sidList in PlayerPrefs");
            }
        }

        public int GetStat(string sid)
        {
            if (!_stats.ContainsKey(sid))
            {
                Debug.LogWarning($"{sid}: no such stat, setting to 0");
                SetStat(sid, 0);
            }

            return _stats[sid];
        }

        public void SetStat(string sid, int value, bool persist = true)
        {
            _stats[sid] = value;

            if (persist)
            {
                PlayerPrefs.SetInt(sid, value);

                if (!_sidList.Contains(sid))
                {
                    _sidList += $"{sid} ";
                    PlayerPrefs.SetString("sidList", _sidList);
                    Debug.Log($"saved updated sidList " + _sidList);
                }
            }
        }
    }
}