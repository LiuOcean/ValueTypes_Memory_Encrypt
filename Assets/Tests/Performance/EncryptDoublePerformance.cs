using Encrypt;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Tests
{
    public class EncryptDoublePerformance
    {
        [Test, Performance]
        public void EncryptSet_10000_10()
        {
            EncryptDouble encrypt = 0;
            Measure.Method(() => { encrypt.Set(1); }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptEqualsSet_10000_10()
        {
            EncryptDouble encrypt = 0;
            Measure.Method(() => { encrypt = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void DoubleSet_10000_10()
        {
            double value = 0;
            Measure.Method(() => { value = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptGet_10000_10()
        {
            EncryptDouble encrypt = 0;
            Measure.Method(
                        () =>
                        {
                            double _ = encrypt;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }

        [Test, Performance]
        public void DoubleGet_10000_10()
        {
            double value = 0;

            Measure.Method(
                        () =>
                        {
                            double _ = value;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }
    }
}