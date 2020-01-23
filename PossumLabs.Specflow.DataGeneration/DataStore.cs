using System;
using System.Collections.Generic;
using System.Text;

namespace PossumLabs.Specflow.DataGeneration
{
    public class DataStore
    {
        public DataStore(string resourceName)
        {
            Name = resourceName;
            Random = new Random();
            Percentile = 100;
        }

        private string[] Options { get; set; }
        private int Length { get; set; }
        private Random Random { get; }

        public string Name { get; }
        public int Percentile { get; set; }

        public void Initialize(string content)
        {
            Options = content.Split('\n');
            Length = Options.Length;
        }

        public string GetValue()
        {
            var percentile = Percentile < 1 ? 1 : Percentile;
            percentile = percentile > 100 ? 100 : percentile;
            return Options[this.Random.Next((Length * percentile) / 100)];
        }
    }
}
