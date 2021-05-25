//B"H

function domemify(gameObject, name) {
	var tr =  findDeepTransform(
		gameObject.transform, name
	)
	
	if(tr) {
		return new Achdus.Domem({
			gameObject: tr.gameObject
		})
	}
	
	return null
}


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


function max(ar) {
	var num = 0
	var i = 0
	var lng = 0
	if(ar["length"]) lng = ar.length
	if(ar["Length"]) lng = ar.Length
	var lastHigh = null
	for(
		i = 0;
		i < lng;
		i++
	) {
		if(lastHigh != null) {
			if(ar[i] > lastHigh)
				lastHigh = ar[i]
		} else
			lastHigh = ar[i]
	}
	
	num = lastHigh
	return num
	
}