using System;
using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
    public class AssetDownloadReporter : IAssetDownloadReporter
    {
        private const float UpdateTreshhold = 0.01f;

        public float Progress { get; private set; }
        public event Action<float> ProgressUpdated;

        public void Report(float value)
        {
            if (Mathf.Abs(Progress - value) < UpdateTreshhold)
                return;

            Progress = value;
            ProgressUpdated?.Invoke(Progress);
        }

        public void Reset() => Progress = 0;
    }
}