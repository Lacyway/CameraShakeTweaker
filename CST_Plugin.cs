using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;

namespace CameraShakeTweaker
{
	[BepInPlugin("com.lacyway.cst", "CameraShakeTweaker", "1.1.0")]
	public class CST_Plugin : BaseUnityPlugin
	{
		public static ManualLogSource CST_Logger;
		public static ConfigEntry<float> ShakeAmount;

		protected void Awake()
		{
			CST_Logger = Logger;
			CST_Logger.LogInfo($"{nameof(CST_Plugin)} has been loaded.");

			ShakeAmount = Config.Bind("Config", "Shake Amount", 1f, new ConfigDescription("The percentage to multiply the shake amount with",
			new AcceptableValueRange<float>(0f, 1f), new ConfigurationManagerAttributes()
			{
				ShowRangeAsPercent = true
			}));

			new ForceEffector_AddForce_Patch().Enable();
		}
	}
}
