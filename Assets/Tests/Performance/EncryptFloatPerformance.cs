using Encrypt;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Tests
{
    public class EncryptFloatPerformance
    {
        [Test, Performance]
        public void EncryptSet_10000_10()
        {
            EncryptFloat encrypt = 0;
            Measure.Method(() => { encrypt.Set(1); }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptEqualsSet_10000_10()
        {
            EncryptFloat encrypt = 0;
            Measure.Method(() => { encrypt = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void FloatSet_10000_10()
        {
            float value = 0;
            Measure.Method(() => { value = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptGet_10000_10()
        {
            EncryptFloat encrypt = 0;
            Measure.Method(
                        () =>
                        {
                            float _ = encrypt;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }

        [Test, Performance]
        public void FloatGet_10000_10()
        {
            float value = 0;

            Measure.Method(
                        () =>
                        {
                            float _ = value;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }
    }
}