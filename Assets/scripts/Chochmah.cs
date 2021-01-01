using System;
using System.Collections.Generic;
namespace Achdus {
	public class Chochmah {
		private Dictionary<
			string, List<Func<object, object>>
		> peulosAchshawv = (
			new Dictionary<string, List<Func<object, object>>>()
		);
		
			
		public Davar cald = 
		new Davar();
		
		public void on(string eventName, Func<object, object> action) {
            if (!peulosAchshawv.ContainsKey(eventName)) {
                peulosAchshawv[eventName] = new List<Func<object, object>>();
            }
			
            peulosAchshawv[eventName].Add((object tmp) => {

                action?.Invoke(tmp);
                return null;
            });

        }

        public void clear(string eventName) {
            if (peulosAchshawv.ContainsKey(eventName)) {
                peulosAchshawv[eventName].Clear();
            }
        }
		
		public void AyshPeula(string peulaShaym, object dvarim) {
			if (peulosAchshawv.ContainsKey(peulaShaym)) {
				peulosAchshawv[peulaShaym]
					.ForEach(x => x(dvarim));
			}
			cald[peulaShaym] = true;
		}
		
		public void onOrNow
		(
			string eventName, 
			Func<object, object> action
		) {
			if(
				cald[eventName] != null
			) {
				action?.Invoke(cald[eventName]);
			} else {
				on(eventName, action);
			}
		}
	}
}