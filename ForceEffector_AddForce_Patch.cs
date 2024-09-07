using SPT.Reflection.Patching;
using System.Linq;
using System.Reflection;

namespace CameraShakeTweaker
{
	public class ForceEffector_AddForce_Patch : ModulePatch
	{
		protected override MethodBase GetTargetMethod()
		{
			return typeof(ForceEffector).GetMethods().Where(x => x.Name == "AddForce" && x.GetParameters().Length == 4).FirstOrDefault();
		}

		[PatchPrefix]
		public static void Prefix(ref float strength)
		{
			strength *= CST_Plugin.ShakeAmount.Value;
		}
	}
}
