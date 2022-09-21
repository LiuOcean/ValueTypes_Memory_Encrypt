using Encrypt;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Tests
{
    public class EncryptSBytePerformance
    {
        [Test, Performance]
        public void EncryptSet_10000_10()
        {
            EncryptSByte encrypt = 0;
            Measure.Method(() => { encrypt.Set(1); }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptEqualsSet_10000_10()
        {
            EncryptSByte encrypt = 0;
            Measure.Method(() => { encrypt = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void SByteSet_10000_10()
        {
            sbyte value = 0;
            Measure.Method(() => { value = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptGet_10000_10()
        {
            EncryptSByte encrypt = 0;
            Measure.Method(
                        () =>
                        {
                            sbyte _ = encrypt;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }

        [Test, Performance]
        public void SByteGet_10000_10()
        {
            sbyte value = 0;

            Measure.Method(
                        () =>
                        {
                            sbyte _ = value;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }
    }
}