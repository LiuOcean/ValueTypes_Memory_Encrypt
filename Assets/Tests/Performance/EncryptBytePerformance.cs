using Encrypt;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Tests
{
    public class EncryptBytePerformance
    {
        [Test, Performance]
        public void EncryptSet_10000_10()
        {
            EncryptByte encrypt = 0;
            Measure.Method(() => { encrypt.Set(1); }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptEqualsSet_10000_10()
        {
            EncryptByte encrypt = 0;
            Measure.Method(() => { encrypt = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void ByteSet_10000_10()
        {
            byte value = 0;
            Measure.Method(() => { value = 1; }).IterationsPerMeasurement(10000).MeasurementCount(10).Run();
        }

        [Test, Performance]
        public void EncryptGet_10000_10()
        {
            EncryptByte encrypt = 0;
            Measure.Method(
                        () =>
                        {
                            byte _ = encrypt;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }

        [Test, Performance]
        public void ByteGet_10000_10()
        {
            byte value = 0;

            Measure.Method(
                        () =>
                        {
                            byte _ = value;
                        }
                    ).
                    IterationsPerMeasurement(10000).
                    MeasurementCount(10).
                    Run();
        }
    }
}