//B"H
Object.defineProperties(
	Array.prototype,
	{
		find: {
			get: function(a) {
				var that = this
				return function(fnc) {
					if(typeof(fnc) == "function") {
						var i = 0;
						for(
							i = 0;
							i < that.length; 
							i ++
						) {
							if(
								fnc(that[i], i, that)
							) {
								return that[i]
							}
						}
						return null
					}
				}
			}
		}
	}
)

function findDeepTransform(t1, name) {
	var it = t1.Find(name)
	if(it) return it;
	else {
		var i, cur;
		for(
			i = 0;
			i < t1.childCount;
			i++
		) {
			cur = findDeepTransform(
				t1.GetChild(i), name
			)
			if(cur) return cur;
		}
		return null;
	}
}