namespace Dreamscape
{
	/// <summary>
	/// Gain will.
	/// </summary>
	public class GainWill : CardEffect {
		/// <summary>
		/// Registers the DrawCard function to the Death event on the CEM.
		/// </summary>
		/// <param name="CEM">The CardEventManager that will be handling the effects.</param>
		public override void RegisterEffects (CardEventManager CEM)
		{
			CEM.Discard += DrawCard;
		}
	}
}

