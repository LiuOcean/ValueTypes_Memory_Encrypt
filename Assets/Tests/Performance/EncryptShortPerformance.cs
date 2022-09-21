using Encrypt;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Tests
{
    public class EncryptShortPerformance
    {
        [Test, Performance]
        public void EncryptSet_10000_10()
        {
            EncryptShort encrypt = 0;
            Measure.Method(() => { encrypt.Set(1); }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptEqualsSet_10000_10()
        {
            EncryptShort encrypt = 0;
            Measure.Method(() => { encrypt = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void ShortSet_10000_10()
        {
            short value = 0;
            Measure.Method(() => { value = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptGet_10000_10()
        {
            EncryptShort encrypt = 0;
            Measure.Method(
                        () =>
                        {
                            short _ = encrypt;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }

        [Test, Performance]
        public void ShortGet_10000_10()
        {
            short value = 0;

            Measure.Method(
                        () =>
                        {
                            short _ = value;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }
    }
}