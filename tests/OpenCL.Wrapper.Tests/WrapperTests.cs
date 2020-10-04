using NUnit.Framework;

using OpenCL.Wrapper.TypeEnums;

namespace OpenCL.Wrapper.Tests
{
    public class WrapperTests
    {
        private const string TEST_KERNEL = @"
__kernel void set_value(__global uchar* arr, uchar value)
{
	int idx = get_global_id(0);
    arr[idx] = value;
}";

        [Test]
        public void SignatureParsing()
        {
            CLAPI instance = CLAPI.GetInstance();
            
            KernelDatabase db = new KernelDatabase(DataVectorTypes.Uchar1);

            CLProgram program = db.AddProgram(instance, TEST_KERNEL, "./", true, out CLProgramBuildResult result);

            CLKernel kernel = program.ContainedKernels["set_value"];

            Assert.True(CheckParameter(kernel.Parameter["arr"], "arr", true, 0, DataVectorTypes.Uchar1, MemoryScope.Global));
            Assert.True(CheckParameter(kernel.Parameter["value"], "value", false, 1, DataVectorTypes.Uchar1, MemoryScope.None));

            db.Dispose();
            instance.Dispose();
        }

        private bool CheckParameter(KernelParameter param,string name, bool isArray, int id, DataVectorTypes type, MemoryScope scope )
        {
            return param.IsArray == isArray &&
                   param.DataType == type &&
                   param.Id == id &&
                   param.MemScope == scope &&
                   param.Name == name;
        }
    }
}