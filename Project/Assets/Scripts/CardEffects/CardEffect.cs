﻿using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	/// <summary>
	/// Abstract Class to that effects that are triggered in response to an event will inherit.
	/// </summary>
	public abstract class CardEffect : MonoBehaviour {
		/// <summary>
		/// Registers the effects.
		/// </summary>
		/// <param name="CEM">The CardEventManager that will be handling the effects.</param>
		public abstract void RegisterEffects (CardEventManager CEM);
	}
}
