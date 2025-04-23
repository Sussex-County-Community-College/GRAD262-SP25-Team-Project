using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


namespace SCCC
{
    public class StatManager : MonoBehaviour
    {
        static public StatManager Instance;

        public bool resetPlayerPrefs = false;

        private string sidList = "";
        private Dictionary<string, int> stats = new Dictionary<string, int>();

        private void Awake()
        {
            if (Instance)
            {
                Debug.LogWarning("StatManager instance already exists");
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            if (resetPlayerPrefs)
            {
                Debug.LogWarning("deleting all PlayPrefs");
                PlayerPrefs.DeleteAll();
            }
            else if (PlayerPrefs.HasKey("sidList"))
            {
                sidList = PlayerPrefs.GetString("sidList");
                string[] sidListTokens = sidList.Split(' ');

                foreach (var sid in sidListTokens)
                {
                    stats[sid] = PlayerPrefs.GetInt(sid);
                    Debug.Log($"loaded persistent stat {sid} value {stats[sid]}");
                }
            }
            else
            {
                Debug.LogWarning("no sidList in PlayerPrefs");
            }
        }

        public int GetStat(string sid)
        {
            if (!stats.ContainsKey(sid))
            {
                Debug.LogWarning($"{sid}: no such stat, setting to 0");
                SetStat(sid, 0);
            }

            return stats[sid];
        }

        public void SetStat(string sid, int value, bool persist = true)
        {
            stats[sid] = value;

            if (persist)
            {
                PlayerPrefs.SetInt(sid, value);

                if (!sidList.Contains(sid))
                {
                    sidList += $"{sid} ";
                    PlayerPrefs.SetString("sidList", sidList);
                    Debug.Log($"saved updated sidList " + sidList);
                }
            }
        }
    }
}