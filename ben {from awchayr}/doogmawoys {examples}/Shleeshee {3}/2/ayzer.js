//B"H
//var ATZMUS = {}
var isawch = window.Achdus 
			&& window.importNamespace
			&& window.System
var q = []
var wrld;		
if(!isawch) {
	
	
	var g = document.createElement("script")
	var shoy = "kayleem/"
	g.src = shoy + "yichoyliss.js"
	document.head.appendChild(g)
	g.onload = function() {
		YICHOYLISS.Tzimtzoom({
			dawfeem: [
				shoy + "three.min",
				shoy + "GLTFLoader",
				shoy + "physx.release",
				shoy + "iu",
				shoy + "awtsmoys",
			],
			olam: {
				listeners: {
					start: function(t) {
						if(wrld) return
						wrld = t
					}
				}
			}
		})
	}
	
	function mt(a) {
		return {x:a||0,y:a||0,z:a||0}
	}
	
	function tf(p,r,s) {
		var rotation = r || mt()
		var position = p || mt()
		var scale = s || mt(1)
		var sl = this
		this.Find = function(s) {
		
		}
		
		this.childCount = 0
		this.gameObject = {}
		this.GetChild = function(s) {
			
		}
		
		Object.defineProperties(this, {
			position: {
				get: function() {
					return position
				},
				set: function(v) {
					"xyz"
					.split("")
					.forEach(function(r) {
						
						if(typeof(v[r]) == "number") {
							position[r] = v[r]
							if(sl.gameObject._pushit) {
								sl
								.gameObject
								._pushit
								.position[r] = v[r]
							}
						} else {
							position[r] = 0
						}
					})
				}
			},
			rotation: {
				get: function() {
					return rotation
				},
				set: function(v) {
					"xyz".split()
					.forEach(function(r) {
						if(typeof(v[r]) == "number") {
							rotation[r] = v[r]
							if(sl.gameObject._pushit) {
								sl
								.gameObject
								._pushit
								.rotation[r] = v[r]
							}
						}
					})
				}
			},
			scale: {
				get: function() {
					return scale
				},
				set: function(v) {
					"xyz".split()
					.forEach(function(r) {
						if(typeof(v[r]) == "number") {
							scale[r] = v[r]
							if(sl.gameObject._pushit) {
								sl
								.gameObject
								._pushit
								.scale[r] = v[r]
							}
						}
					})
				}
			}
		})
	}
	
	window.UnityEngine = new function() {
		this.Vector3 = function(_x,_y,_z) {
			this.x = _x || 0
			this.y = _y || 0
			this.z = _z || 0
		}
		
		this.GameObject = function(n) {
			this.name = n
			var transform = new tf()
			transform.gameObject = this
			Object.defineProperties(this, {
				transform: {
					get: function() {
						return transform
					}
				}
			})	
		}
	}
	
	function doQ() {
		if(!isawch) {
			Achdus.Yaakov.mainCoby.ikarAyin.mishawnehGoof("ayin")
			q.forEach(function(w) {
				w.onCreate()
			})
			gawshmeeoos()
		}
	}
	var hh = "yich://"
	window.Achdus = new function() {
		var slf = this
		this.Domem = function(a) {
			var doy = this
			this.dayuh = {}
			
			if(!a) a = {}
			var p = a.position || mt(),
				r = a.rotation || mt(),
				s = a.scale || mt(1),
				
				ini = a.Init,
				fx = a.FixedUpdate,
				md = a.model,
				c = a.color,
				
				_p = a._pushit,
				gob = a.gameObject
				
			if(typeof(gob) == "string") {
				this.gameObject = g(gob)
			} else {
				this.gameObject = new UnityEngine.GameObject();
			}
			
			function g(s) {
				return new UnityEngine.GameObject();
			
			}
			this.PlayChayoosFade = function(f) {
				if(doy._push) {
					doy._push.playChayoos(f)
				}
			}
			
			this.PlayChayoos = function(f) {
				if(doy._push) {
					doy._push.playChayoos(f)
				}
			}
			
			
			this._push = null
			
			this.onCreate = function() {
				if(typeof(ini) == "function")
					ini(doy)
				var oy = {
					position: doy
							.gameObject
							.transform
							.position,
					rotation: doy
							.gameObject
							.transform
							.rotation,
					scale: doy
							.gameObject
							.transform
							.scale
							
				}
				
				if(typeof(md) == "string") {
					if(md.indexOf(hh) > -1) {
						oy.model = YICHOYLISS
							.oytzayr[
								md.substring(hh.length)
							]
					} else {
						oy.model = md
					}
				}
				
				if(a.empty) oy.empty = a.empty
				
				if(typeof(c) == "string") {
					oy.tzurah = {
						type:"lambert",
						arguments: [
							{
								color: c
							}
						]
					}
				}
				
				if(typeof(_p) == "string") {
					doy._push = wrld[_p]
				} else {
					if(gob != "empty")
						doy._push = new YICHOYLISS.Nivra(oy)
				}
				
				doy.gameObject._pushit = doy._push
				
				doy._push.on("hissHavoos", function() {
					if(typeof(fx) == "function")
						fx(doy)
				})
				
				wrld.hoyseef(doy._push)
				
				
				doy.gameObject.transform.position = p
				doy.gameObject.transform.rotation = r
				doy.gameObject.transform.scale = s
			}
			
			
			if(wrld) {
				doy.onCreate()
				
			} else {
				q.push(this)
			}
			
			this.mishawnehGoof = function(n) {
				var gh;
				if(typeof(n) == "string") {
					gh = wrld[n]
				} else if(n != 444) {
					gh = new YICHOYLISS.Nivra(oy)
				} else {
					
				}
				doy.gameObject._pushit = gh
				doy.gameObject.transform = doy.gameObject.transform
				//gh.transform = doy.gameObject.transform
				
			}
		}
		//if(!doy._push)
		this.Tzomayach = function(a) {
			slf.Domem.call(this,a)
		}
		
		this.Chai = function(a) {
			slf.Tzomayach.call(this,a)
		}
		
		this.Medabeir =function(a) {
			slf.Chai.call(this,a)
		}
		
		this.Chossid = function(a) {
			slf.Medabeir.call(this,a)
		}
		
		this.Cob = new function() {
			this.on = function(s) {
				
			}
		}
		
		this.Yaakov = new function() {
			this.mainCoby = new function() {
				this.ikarAyin = new slf.Domem({
				//	gameObject: "empty"
				})
				
			}
		}
	}
	
	
	function gawshmeeoos() {
		// Setup
/*
		const PhysX = PHYSX({
		  locateFile(path) {
			if (path.endsWith('.wasm')) {
			  return YICHOYLISS.oytzayr["kayleem/iu"]
			}
			return path
		  }
		})

		let resolve
		const promise = new Promise((res) => {
		  resolve = res
		})

		PhysX.ready = () => promise
		PhysX.onRuntimeInitialized = () => {
		  PhysX.loaded = true
		  resolve()
		}

		window.PhysX = PhysX

		// Usage

		PhysX.ready().then(function () {
		  console.log('Boruch Hashem')
		  const filterData = new PhysX.PxFilterData(0, 0, 0, 0)
		  // ....
		})*/
	}
	/*window.defineProperties({
		importNamespace: {
			get: function() {
				
			}
		}
	})*/
}
window.addEventListener("load", function(m) {
	
	doQ();
	
	addEventListener("keydown", function(e) {
		ATZMUS.mawftaychoys[e.keyCode] = true
	})
	
	addEventListener("keyup", function(e) {
		ATZMUS.mawftaychoys[e.keyCode] = false
	})
	
	var s = document.getElementsByTagName("script")
	var yt = Array.apply(0,s).find(function(t) {
		
		return t.type == "etzem"
	})
	if(yt) {
		var txt = yt
			.innerText
			.split("וורד")
			.join("var")
			.split("אור")
			.join("new")
		//var sc = document.createElement("script")
		//sc.innerText = txt
		//yt.parentNode.appendChild(sc)
		eval(txt)
		
	}
	
});

(function () {


var coym,it,mawf = {};

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
Object.defineProperty(
	window,
	"עצמות",
	{
		get: function() {
			return ATZMUS
		}
	}
)
Object.defineProperties(
ATZMUS, {
	etzem: {
		get: function() {
			return 5
		}
	},
	היולי: {
		get: function() {
			return function(a) {
				if(!a) a = {}
				var that = this
				var kaychoyss = {}
				var hoynuchaws = {}
				Object.defineProperties(
					this,
					{
						kaychoyss: {
							get: function() {
								return kaychoyss
							}
						},
						hoynuchaws: {
							get: function() {
								return hoynuchaws
							}
						},
				
						koyvayuh: {
							get: function() {
								return function(id,fnc) {
									if(
										typeof(fnc) 
										== "function" &&
										typeof(id) 
										== "string"
									) {
										
										
										kaychoyss[id] = 
										function() {
											return fnc(
												this[id]
											)
										}
									} else if (
										typeof(id) == 
										"string" &&
										typeof(fnc) == 
										"object"
									) {
										if(
											typeof(fnc.kach) ==
											"function"
										) {
											kaychoyss[id] = 
											function() {
												return fnc.kach(
													this[id]
												)
											}
										}
										
										if(
											typeof(fnc.hawnach) ==
											"function"
										) {
											hoynuchaws[id] = 
											function(v) {
												return fnc
												.hawnach(
													v,
													that
												)
											}
										}
									}
								}
							}
						}
					}
				)
			}
		}
	},
	Heeoolee: {
		get: function() {
			return ATZMUS.היולי
		}
	},
	
	קו: {
		get: function() {
			return function(ok) {
				ATZMUS.היולי.call(this, ok)
				var aleph = 0,
					bays = 0,
					gimel = 0
				var that = this
				
				var offset;
				Object.defineProperties(
					this,
					{
						
						aleph: {
							get: function() {
								
								if(that.kaychoyss["aleph"]) {
									var a =
									that.kaychoyss["aleph"]()
									var a = that
									.kaychoyss["aleph"]()
									if(
										typeof(a) == "number"
									) {
										aleph = a
									}
									
								}
								return aleph
							},
							set: function(v) {
								var val = v;
								if(
									that.hoynuchaws["aleph"]	
								) {
									var a = that
									.hoynuchaws["aleph"](
										v
									)
									if(
										typeof(a) == "number"
									) {
										val = a
									}
								}
								aleph = val
							}
						},
						bays: {
							get: function() {
								if(that.kaychoyss["bays"]) {
									var a =
									that
									.kaychoyss["bays"]()
									var a = that
									.kaychoyss["bays"]()
									if(
										typeof(a) == "number"
									) {
										bays = a
									}
									
								}
								return bays
							},
							set: function(v) {
								var val = v;
								if(
									that
									.hoynuchaws["bays"]	
								) {
									var a = that
									.hoynuchaws["bays"](
										v
									)
									if(
										typeof(a) == "number"
									) {
										val = a
									}
								}
								bays = val
							}
						},
						gimel: {
							get: function() {
								if(that.kaychoyss["gimel"]) {
									var a =
									that.kaychoyss["gimel"]()
									var a = that
									.kaychoyss["gimel"]()
									if(
										typeof(a) == "number"
									) {
										gimel = a
									}
									
								}
								return gimel
							},
							set: function(v) {
								var val = v;
								if(
									that.hoynuchaws["gimel"]	
								) {
									var a = that
									.hoynuchaws["gimel"](
										v
									)
									if(
										typeof(a) == "number"
									) {
										val = a
									}
								}
								gimel = val
							}
						},
						x: {
							get: function() {
								return this.aleph
							},
							set: function(v) {
								this.aleph = v
							}
						},
						y: {
							get: function() {
								return this.bays
							},
							set: function(v) {
								this.bays = v
							}
						},
						z: {
							get: function() {
								return this.gimel
							},
							set: function(v) {
								this.gimel = v
							}
						},
						a: {
							get: function() {
								return this.aleph
							},
							set: function(v) {
								this.aleph = v
							}
						},
						b: {
							get: function() {
								return this.bays
							},
							set: function(v) {
								this.bays = v
							}
						},
						g: {
							get: function() {
								return this.gimel
							},
							set: function(v) {
								this.gimel = v
							}
						},
						א: {
							get: function() {
								return this.aleph
							},
							set: function(v) {
								this.aleph = v
							}
						},
						ב: {
							get: function() {
								return this.bays
							},
							set: function(v) {
								this.bays = v
							}
						},
						ג: {
							get: function() {
								return this.gimel
							},
							set: function(v) {
								this.gimel = v
							}
						},
						offset: {
							get: function() {
								return offset;
							},
							set: function(v) {
								if(!offset) {
									offset = new ATZMUS.Kav({
										yesod:v
									})
								} else {
									offset.hoynawch({
										yesod:v
									})
								}
								
								that
								.aleph +=
								offset.aleph
								
								that
								.bays +=
								offset.bays
								
								that
								.gimel +=
								offset.gimel
								
							}
						},
						
						הנך: {
							get: function() {
								return hoynach;
							}
						},
						hanach: {
							get: function() {
								return hoynach;
							}
						},
						hoynach: {
							get: function() {
								return hoynach;
							}
						},
						hawnach: {
							get: function() {
								return hoynach;
							}
						},
						hoynawch: {
							get: function() {
								
								return function(v) {
									
									hoynach(v)
			
								};
							}
						},
						
						to: {
							get: function() {
								return function() {
									return ({
										aleph:aleph,
										bays:bays,
										gimel:gimel
									})
								}
							}
						}
					}
				)
				
				
				function cheepaysh(ar, el) {
					if(typeof(ar[el]) == "object") {
						var k = ar[el]["kach"]
						var hn = ar[el].hawnach
						
						if(typeof(k) != "function") {
							k = function(){}
						}
						
						if(typeof(hn) != "function") {
							hn = function(){}
						}
						
						that.koyvayuh(el, {
							kach:k,
							hawnach: hn
						})
					}
					
					if(typeof(ar[el] == "function")) {
						that.koyvayuh(el, ar[el])
					}
				}
				
				hoynach(ok)
				function hoynach(ok) {
					var a, b, c, koy
					if(
						typeof(ok.koyvayuh)	
						== "object"
					) {
						koy = ok.koyvayuh
					}
					if(typeof(koy) == "object") {
						cheepaysh(
							koy, "aleph"
						)
						cheepaysh(
							koy, "bays"
						)
						cheepaysh(
							koy, "gimel"
						)
					}
					
					if(
						typeof(ok.yesod) == "object"
					) {
						if(typeof(ok.yesod[0]) == "number") {
							a = ok.yesod[0]
							
							if(typeof(ok.yesod[1]) == "number") {
								b = ok.yesod[1]
								if(typeof(ok.yesod[2]) == "number")
									c = ok.yesod[2]
							}
						} else {
							a = ok.yesod
						}
					} else {
						a = ok.yesod
					}
					if(
						typeof(a) == "number" &&
						typeof(b) != "number"
					) {
						that.aleph 
						= that.bays 
						= that.gimel = a
						
					} else if(
						typeof(a) == "number" &&
						typeof(b) == "number" &&
						typeof(c) == "number"
					) {
						
						that.aleph = a
						that.bays = b
						that.gimel = c
						
					}
					
					
					if(typeof(a) == "object") {
						
						if(typeof(a.aleph) == "number") {
							that.aleph = a.aleph
						} else if(typeof(a["א"]) == "number") {
							that.aleph = a["א"]
						} else if(typeof(a.x) == "number") {
							that.aleph = a.x
						} else if(typeof(a.a) == "number") {
							that.aleph = a.a
						}
						
						
						if(typeof(a.bays == "number")) {
							that.bays = a.bays
						}

						if(typeof(a["ב"]) == "number") {
							that.bays = a["ב"]
						}

						if(typeof(a.y) == "number") {
							that.bays = a.y
						}

						if(typeof(a.b) == "number") {
							that.bays = a.b
						}
						
						if(typeof(a.gimel) == "number") {
							that.gimel = a.gimel
						} else if(typeof(a["ג"]) == "number") {
							that.gimel = a["ג"]
						}  else if(typeof(a.z) == "number") {
							that.gimel = a.z
						}else if(typeof(a.g) == "number") {
							that.gimel = a.g
						}
						
						var oyr = a.offset ||
							a.oyfset
						
						var k = a.ikar ||
								a.yesod
						if(
							typeof(k) ==
							"object"
						) {
							k.offset = oyr
							return hoynach({
								yesod: k
							})
						}
						
						
						if(oyr) {
				
							that.offset = oyr;
	
						}
						
						
						
					}
				}
				
			}
		}
	},
	Kav:{
		get: function() {
			return ATZMUS.קו
		}
	},
	
	נברה: {
		get: function() {
			return function(a) {
				if(!a) a = {}
				var trigg = a.isTrigger
				
				var self = this;
				var ms = a.meen,
					neef = a.Neefgash
				if(typeof(ms) != "string") 
					ms = "Domem"
				var ups = [
					["HeessCheel", "heesscheel"],
					["HeessCheel", "HeessCheel"],
					["HeessCheel", "Heesscheel"],
					["HeessCheel", "Init"],
					["HeessCheel", "Start"],
					["HeessCheel", "Begin"],
					["HeessCheel", "Awake"],
					["HeessCheel", "Neeor"],
					["HeessCheel", "neeor"],
					["FixedUpdate","hissHavoos"],
					["FixedUpdate","HissHavoos"],
					["FixedUpdate","HissHavooss"],
					["LateUpdate","meooycharHissHavoos"],
					["LateUpdate","lateHissHavoos"],
					["Update","update"],
					["Update","Update"],
					["FixedUpdate","fixedUpdate"],
					["FixedUpdate","FixedUpdate"]
				]
				
				var fncs = {}
				
				ups.forEach(function(x) {
					if(
						typeof(
							a[x[1]]
						) == "function"
					) {
						if(!fncs[x[0]]) 
							fncs[x[0]] = []
						fncs[x[0]].push(a[x[1]])
					}
				})
				
				if(Achdus[ms]) {
					var str = false
					var go = a.gameObject
					var goof = a.goof ||
							a.guf ||
							a.גוף ||
							a.model ||
							a.body;
					
					
					var oyb = {
						Init: function(a) {
							a.dayuh.dayuh = {}
						//	a.dayuh.str = false
							
							
							if(
								fncs[
									"FixedUpdate"
								] ||
								fncs[
									"Update"
								]
							) {
								a.dayuh.neev = true
							}
							
							if(ms == "Domem" ||
								ms == "Tzomayach" ||
								ms == "Afar")
							a.nivraTriggers
							/*
							if(fncs["HeessCheel"]) {
								fncs["HeessCheel"]
								.forEach(function(b)
								{
									b(self);
								})
							}
							*/
							
						},
						LateUpdate: function(a) {
							if(fncs["LateUpdate"]) {
								fncs["LateUpdate"]
								.forEach(function(b)
								{
									b(self);
								})
							}
						},
						Update: function(a) {
							if(fncs["Update"]) {
								fncs["Update"]
								.forEach(function(b)
								{
									b(self);
								})
							}
						},
						FixedUpdate: function(a) {
							if(!a.dayuh.str) {
								a.dayuh.str = true
								
								//if(a.dayuh.neev)
								//	a.nivraTriggers = null
									
								if(fncs["HeessCheel"]) {
									fncs["HeessCheel"]
									.forEach(function(b)
									{
										b(self);
									})
									
								}
								if(trigg) {
									console.log("TRIF")
									a.isTrigger = true
								}
							}
							
							if(
								fncs["FixedUpdate"]
							) {
								fncs["FixedUpdate"]
								.forEach(function(b)
								{
									b(self);
								})
							}
						}
					}
					
					if(
						typeof(go) == "object" ||
						typeof(go) == "string"
					) {
						oyb.gameObject = go;
					}
					
					if(a.name) {
						oyb.name = a.name
					}
					
					if(neef) {
						oyb.Neefgash = neef
					}
					
					if(a.TriggerEnter) {
						oyb.TriggerEnter = function(c) {
						/*	var cl = {
								
							}
							var awt = new ATZMUS.Domem({
								gameObject: c.gameObject
							})*/
							a.TriggerEnter(c)
						//	a.TriggerEnter(awt)
						}
						
					}
					if(a.TriggerExit) {
						oyb.TriggerExit = a.TriggerExit
					}
					
					if(a.CollisionEnter) {
						oyb.CollisionEnter = a.CollisionEnter
					}
					
					if(a.CollisionExit) {
						oyb.CollisionExit = a.CollisionExit
					}
					
					if(a.CollisionStay) {
						oyb.CollisionStay = a.CollisionStay
					}
					
					if(a.ControllerColliderHit) {
						oyb.ControllerColliderHit = a.ControllerColliderHit
					}
					
					if(a.name) {
						oyb.name = a.name
					}
					if(a.shaym) {
						oyb.shaym = a.shaym
					}
					
					
					
					if(typeof(goof) == "string") {
						oyb.model = goof;
					}
					
					var pashut = new Achdus[
							ms
						](oyb);
					
					Object.defineProperties(
					this, 
						{
							tag: {
								get: function() {
									if(pashut) {
										return (
											pashut
											.gameObject
											.tag
										)
										
									}
								},
								set: function(v) {
									if(
										pashut &&
										typeof(v) 
										== "string"
									) {
										
										pashut
										.gameObject
										.tag = v
										
										
									}
								}
							},
							dayuh: {
								get: function() {
									return pashut.dayuh.dayuh
								}
							},
							pashut: {
								get: function() {
									return pashut
								}
							},
							shaym: {
								get: function() {
									
									pashut.shaym = true
								},
								set: function(v) {
									pashut.shaym = v
								}
							},
							name: {
								get: function() {
									
									pashut.name = true
								},
								set: function(v) {
									pashut.name = v
								}
							},
							isTrigger: {
								get: function() {
									
									return pashut.isTrigger
								},
								set: function(v) {
									pashut.isTrigger = v
								}
							},
							nivraTriggers: {
								get: function() {
									return pashut.nivraTriggers
								},
								set: function(v) {
									pashut.nivraTriggers = v
								}
							},
							gameObject: {
								get: function() {
									return pashut.gameObject
								}
							},
						/*	shaym: {
								get: function() {
									return pashut
										.gameObject
										.name
								},
								set: function(v) {
									pashut
										.gameObject
										.name = v
								}
							},*/
							name: {
								get: function() {
									return pashut
										.gameObject
										.name
								},
								set: function(v) {
									pashut
										.gameObject
										.name = v
								}
							},
							גוף: {
								get: function() {
									return goof
								},
								set: function(v) {
									
								}
							},
							goof: {
								get: function() {
									return גוף
								}
							},
							guf: {
								get: function() {
									return גוף
								}
							},
							body: {
								get: function() {
									return גוף
								}
							},
							model: {
								get: function() {
									return גוף
								}
							},
						}
					)
				}
			}
		}
	},
	
	Nivra: {
		get: function() {
			return ATZMUS.נברה
		}
	},
	mawftaychoys: {
		get: function() {
			return mawf;
		}
	},
	ikarAyin: {
		get: function() {
			if(!coym) {
				if(!it) {
					it = Achdus
					.Yaakov
					.mainCoby
					.ikarAyin
				}
				if(it) {
					var tawr
					var dir = 0,
						mx=0, mz=0, my=0,
						ms = 0.2,
						dx = 0,dz = 0,
						sp = 3
						
						/*113 = q
						101=e
						119=w
						115=s
						100=d
						97=a
						*/
					coym = new ATZMUS.Domem({
						gameObject: it.gameObject,
						HissHavoos: function(a) {
							
							if(tawr) {
								if(ATZMUS.mawftaychoys[114])
									dz -= sp
								if(ATZMUS.mawftaychoys[102])
									dz += sp
								if(ATZMUS.mawftaychoys[116])
									dx -= sp
								if(ATZMUS.mawftaychoys[103])
									dx += sp
								
								dir = tawr.rotation.y  * Math.PI / 180
								a.position.x = tawr.position.x
									+ Math.sin(dir)* 0.2 
									
								a.position.z = tawr.position.z
									+ Math.cos(dir) * 0.2
							//		+ Math.sin(my) * 0.2
								a.position.y = tawr.position.y
								
								a.rotation.y = tawr.rotation.y
									+ dx
								//	+ dz
									//+ my * 4
									
								a.rotation.x = tawr.rotation.x
									+ dz
									//+ mx * 2 * Math.PI
							}
						}
					})
					
					coym.royay = function(b) {
						
					}
					
					coym.hawlawch = function(a) {
						tawr = a
						a.yetzirah.enabled = false
					}
				}	
			
			}
			return coym;
		}
	},
	
	דומם:{
		get: function() {
			return this.Domem
		}
	},
	Domem: {
		get: function() {
			return function(a) {
				if(!a) a = {}
				
				ATZMUS.Nivra.call(this, a)
				var pashut = this.pashut;
				var self = this
				
				var gav = a.גוון ||
							a.gavan ||
							a.gavvan ||
							a.gavaan ||
							a.gaavan ||
							a.color || 
							"",
							tr = a.triggers,
							hl = a.hehlehm,
							ma = a.mawkoymoys
				var cls = {
					כחול:"blue",
					סרוק:"red",
					ם:"yellow"
				}
				if(typeof(gav) != "string") {
					gav = "blue"
				}
				
				var gavan
				
				var tzeeor = a.ציור ||
					a.tziur ||
					a.tzeeor ||
					a.texture
					
				var tzst
				
				
				var fnd = {}
				function heess(b) {
					self.tziur = tzeeor
					if(gav) self.color = gav
					
					
					if(tr && tr.forEach) {
						tr.forEach(function(a) {
							var c = self.cheepaysh(a)
							if(c) {
								fnd[a] = c
								c.pashut.isTrigger
								c.pashut.collider.convex = true
								c.pashut.isTrigger = true
								if(hl && hl.includes && hl.includes(a)) {
									c.pashut.renderer.enabled = false;
								//	fnd.push(a)
								}
								
								
							}
						})
					}
					
					if(hl && hl.forEach) {
						self.hawlaym(hl)
					}
					
					
				
					
					if(ma) {
						var k;
						for(k in ma) {
							var fn = self.cheepaysh(k)
							if(fn) {
								var mn = ma[k].meen
								if(
									mn
								) {
									var nw = new ATZMUS
										[mn]
										(
											ma[k]
										)
									nw.position = fn
												.position
									
									nw.rotation = fn
												.rotation
									
								}
							}
						}
					}
				}
	
				var makom = new ATZMUS.Kav({
					yesod: a.makom ||
						a.מקום ||
						a.position,
					koyvayuh: {
						aleph: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.position
									.x
							},
							hawnach: function(v,a) {
								if(pashut)
								pashut
									.gameObject
									.transform
									.position
									= new UnityEngine
										.Vector3(
											v,
											a.y,
											a.z
										)
							}
						},
						bays: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.position
									.y
							},
							hawnach: function(v, a) {
								if(pashut)
								if(v) {
								pashut
									.gameObject
									.transform
									.position
									= new UnityEngine
										.Vector3(
											a.x,
											v,
											a.z
										)
								}
							}
						},
						gimel: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.position
									.z
							},
							hawnach: function(
								v,
								a
							) {
								if(pashut)
								if(v)
								pashut
									.gameObject
									.transform
									.position
									= new UnityEngine
										.Vector3(
											a.x,
											a.y,
											v
										)
							}
						}
					}
				}),
				
				
				kawmoys = new ATZMUS.Kav({
					yesod: a.kawmoys ||
						a.kamos ||
						a.כמות ||
						a.scale,
					koyvayuh: {
						aleph: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.localScale
									.x
							},
							hawnach: function(v,a) {
								if(pashut)
								pashut
									.gameObject
									.transform
									.localScale
									= new UnityEngine
										.Vector3(
											v,
											a.y,
											a.z
										)
							}
						},
						bays: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.localScale
									.y
							},
							hawnach: function(v, a) {
								if(pashut)
								if(v) 

								pashut
									.gameObject
									.transform
									.localScale
									= new UnityEngine
										.Vector3(
											a.x,
											v,
											a.z
										)
								
							}
						},
						gimel: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.localScale
									.z
							},
							hawnach: function(
								v,
								a
							) {
								if(pashut)
								if(v)
								pashut
									.gameObject
									.transform
									.localScale
									= new UnityEngine
										.Vector3(
											a.x,
											a.y,
											v
										)
							}
						}
					}
				}),
				
				seaboov = new ATZMUS.Kav({
					yesod: a.seaboov ||
						a.seeboov ||
						a.סיבוב ||
						a.rotation,
					koyvayuh: {
						aleph: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.eulerAngles
									.x
							},
							hawnach: function(v,a) {
								if(pashut)
								pashut
									.gameObject
									.transform
									.eulerAngles
									= new UnityEngine
										.Vector3(
											v,
											a.y,
											a.z
										)
							}
						},
						bays: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.eulerAngles
									.y
							},
							hawnach: function(v, a) {
								if(pashut)
								if(v) {
								pashut
									.gameObject
									.transform
									.eulerAngles
									= new UnityEngine
										.Vector3(
											a.x,
											v,
											a.z
										)
								}
							}
						},
						gimel: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.eulerAngles
									.z
							},
							hawnach: function(
								v,
								a
							) {
								if(pashut)
								if(v)
								pashut
									.gameObject
									.transform
									.eulerAngles
									=  new UnityEngine
										.Vector3(
											a.x,
											a.y,
											v
										)
							}
						}
					}
				});
				
				soyvayvhawawmeesee = new ATZMUS.Kav({
					yesod: a.soyvayvhawawmeesee ||
						a.trueRotation ||
						a.סיבוב_האמיתי ||
						a.mihawlaych,
					koyvayuh: {
						aleph: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.rotation
									.x
							},
							hawnach: function(v,a) {
								if(pashut)
								pashut
									.gameObject
									.transform
									.eulerAngles
									= new UnityEngine
										.Vector3(
											v,
											a.y,
											a.z
										)
							}
						},
						bays: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.rotation
									.y
							},
							hawnach: function(v, a) {
								if(pashut)
								if(v) {
								pashut
									.gameObject
									.transform
									.eulerAngles
									= new UnityEngine
										.Vector3(
											a.x,
											v,
											a.z
										)
								}
							}
						},
						gimel: {
							kach:function(a) {
								if(pashut)
								return pashut
									.gameObject
									.transform
									.rotation
									.z
							},
							hawnach: function(
								v,
								a
							) {
								if(pashut)
								if(v)
								pashut
									.gameObject
									.transform
									.rotation
									=  new UnityEngine
										.Vector3(
											a.x,
											a.y,
											v
										)
							}
						}
					}
				});
				
				var toyld
				var mawt = null
				Object.defineProperties(
					this, 
					{
						
						פשוט: pashut,
						migawleh: {
							get: function() {
								return function(hl) {
									if(hl) {
										hl.forEach(function(a) {
											var c;
											if(fnd[a]) {
												c = fnd[a]
											} else {
										//	if(fnd.indexOf(a) == -1) {
												c = self.cheepaysh(a)
												fnd[a] = c
												
											}
											if(c) {
												
												c.pashut.renderer.enabled = true;
											}
										//	}
										})
									} else if(pashut)
										pashut.renderer.enabled = true;
								}
							}
						},
						hawlaym: {
							get: function() {
								return function(hl) {
									console.log("YO!!",pashut,hl)
									/*if(hl) {
										hl.forEach(function(a) {
											var c;
											if(fnd[a]) {
												c = fnd[a]
											} else {
										//	if(fnd.indexOf(a) == -1) {
												c = self.cheepaysh(a)
												fnd[a] = c
												
											}
											if(c) {
												
												c.pashut.renderer.enabled = false;
											}
										//	}
										}
									}
									else */if(pashut) {
										pashut.renderer.enabled = false;
									}
									
								}
							}
						},
						cheepaysh: {
							get: function() {
								return function(a) {
									if(pashut) {
										var tr = findDeepTransform(
											pashut
											.gameObject
											.transform,
											a
										)
										var m = a.meen ||
											a.type
										if(typeof(m) != "string") {
											m = "Tzomayach"
										}
										
										if(tr && tr.gameObject) {
											var n = new ATZMUS
											[m]({
											//	meen: m,
												gameObject: 
												tr.gameObject,
												name: tr
													.gameObject
													.name
											})
											return n
										} else return null
									}
									return null;
								}
							}
						},
						מקום: {
							get: function() {
								return makom
							},
							set: function(a) {
								makom.hoynawch({
									yesod: a
								})
							}
						},
						makom: {
							get: function() {
								return this.מקום
							},
							set: function(v) {
								this.מקום = v
							}
						},
						position: {
							get: function() {
								return this.מקום
							},
							set: function(v) {
								this.מקום = v
							}
						},
						
						כמות: {
							get: function() {
								return kawmoys
							},
							set: function(a) {
								kawmoys.hoynawch({
									yesod: a
								})
							}
						},
						kawmoys: {
							get: function() {
								return this.כמות
							},
							set: function(v) {
								this.כמות = v
							}
						},
						scale: {
							get: function() {
								return this.כמות
							},
							set: function(v) {
								this.כמות = v
							}
						},
						סיבוב: {
							get: function() {
								return seaboov
							},
							set: function(a) {
								seaboov.hoynawch({
									yesod: a
								})
							}
						},
						seaboov: {
							get: function() {
								return this.סיבוב
							},
							set: function(v) {
								this.סיבוב = v
							}
						},
						seeboov: {
							get: function() {
								return this.סיבוב
							},
							set: function(v) {
								this.סיבוב = v
							}
						},
						rotation: {
							get: function() {
								return this.סיבוב
							},
							set: function(v) {
								this.סיבוב = v
							}
						},
						toldos: {
							get: function() {
								if(pashut) {
									return Array.apply(0,
										pashut
										.gameObject
										
									)
								}
							}
						},
						av: {
							get: function() {
								if(pashut) {
									return pashut
										.gameObject
										.transform.parent
									
								}
							},
							set: function(a) {
								if(pashut) {
									pashut
									.gameObject
									.transform
									.SetParent(
										a
										.pashut
										.gameObject
										.transform
									)
								}
							}
						},
						hawMSסיבוב: {
							get: function() {
								return soyvayvhawawmeesee
							},
							set: function(a) {
								soyvayvhawawmeesee
								.hoynawch({
									yesod: a
								})
							}
						},
						soyvayvhawawmeesee: {
							get: function() {
								return this.hawMSסיבוב
							},
							set: function(v) {
								this.hawMSסיבוב = v
							}
						},
						גוון: {
							get: function() {
								return gavan
							},
							set: function(v) {
								if(typeof(v) == "string") {
									gavan = v
									if(pashut) {
										pashut.color = gavan
										
									}
								}
							}
						},
						
						gavan: {
							get: function() {
								return this.גוון
							},
							set: function(v) {
								this.גוון = v
							}
						},
						gavaan: {
							get: function() {
								return this.גוון
							},
							set: function(v) {
								this.גוון = v
							}
						},
						color: {
							get: function() {
								return this.גוון
							},
							set: function(v) {
								this.גוון = v
							}
						},
						
						ציור: {
							get: function() {
								return tzst
							},
							set: function(value) {
								
								var tzeeorup = value
								
								if(
									typeof(tzeeorup) 
									== "string"
								) {
									
									
									var loyd = Achdus
												.Tzirum
												.GetTexture(tzeeorup)
									if(!loyd) {
										Achdus.Tzirum.LoadTexture({
											name: tzeeorup,
											url: tzeeorup
										})
										loyd = Achdus
												.Tzirum
												.GetTexture(tzeeorup)
									}
								
									tzst =loyd
								}
								if(
									typeof(tzeeorup) 
									== "object"
								) {
									var n = tzeeorup.שם ||
										tzeeorup.name ||
										tzeeorup.shaym ||
										tzeeorup.shem
									var pth = tzeeorup.דרך ||
										tzeeorup.derech ||
										tzeeorup.path ||
										tzeeorup.way ||
										tzeeorup.url
										
									if(typeof(n) == "string") {
										Achdus.LoadTexture({
											name:n,
											url:pth
										})
										tzst = Achdus.Tzirum.GetTexture(n)
									}
									
									
								}

								if(pashut) {
								
									if(
										tzst
									) {
									
									//	pashut.texture = tzst
										
										if(!mawt) {
											mawt = 
											new UnityEngine
												.Material(
													UnityEngine
													.Shader.Find(
														"Transparent/Diffuse"
													)
												)
											mawt.mainTexture = tzst	
											if(
												pashut
												.renderer
											)
											pashut
											.renderer
											.material = mawt
										}
										
									}
									
								}
								
							}
						},
						
						יצירה: {
							get: function() {
								return pashut.renderer
							},
							set: function(v) {
								pashut.renderer = v
							}
						},
						yetzirah: {
							get: function() {
								return this.יצירה
							},
							set: function(v) {
								this.יצירה = v
							}
						},
						tziur: {
							get: function() {
								return this.ציור
							},
							set: function(v) {
								this.ציור = v
							}
						},
						texture: {
							get: function() {
								return this.ציור
							},
							set: function(v) {
								this.ציור = v
							}
						}
					}					
				)
				heess(a)
			
			}
		}
	},
	
	צומח: {
		get: function() {
			return function(a) {
				if(!a) a = {}
				if(!a.meen)
					a.meen = "Tzomayach"
				var self = this
				
				
				Object.defineProperties(this, {
					PlayChayoosFade: {
						get: function() {
							return self.matzmeeachChayoosHester
						}
					},
					PlayChayoos: {
						get: function() {
							return self.matzmeeachChayoos
						}
					},
					matzmeeachChayoosHester: {
						get: function() {
							return function(str) {
								if(self.pashut) {
									self.pashut.PlayChayoosFade(
										str
									)
								}
							}
						}
					},
					matzmeeachChayoos: {
						get: function() {
							return function(str) {
								if(self.pashut) {
									console.log("AA",str)
									self.pashut.PlayChayoos(
										str
									)
								}
							}
						}
					},
					OymaydChayoos: {
						get: function() {
							return function(str) {
								if(self.pashut) {
									self.pashut.PlayChayoos(
										str
									)
								}
							}
						}
					}
					
				})
				
				ATZMUS.Domem.call(this, a);
			}
		}
	},
	Tzomayach: {
		get: function() {
			return ATZMUS.צומח
		}
	},
	
	Tzoymayach: {
		get: function() {
			return ATZMUS.צומח
		}
	},
	
	חי: {
		get: function() {
			return function(a) {
				if(!a) a = {}
				ATZMUS.Tzoymayach.call(this, a)
				//if(!a.meen) a.meen = "Chai"
				var sol = this.cheepaysh("solid")
				if(sol) {
					
					//sol.yetzirah.enabled=0
					
				}
				
			}
		}
	},
	Chai: {
		get: function() {
			return ATZMUS.חי
		}
	},
	מדבר: {
		get: function() {
			return function(a) {
				if(!a) a = {}
				if(!a.meen)
					a.meen = "Medabeir"
				ATZMUS.Chai.call(this, a)
			}
		}
	},
	Medabeir: {
		get: function() {
			return ATZMUS.מדבר
		}
	},
	Medabayr: {
		get: function() {
			return ATZMUS.מדבר
		}
	},
	
	חסיד: {
		get: function() {
			return function(a) {
				if(!a) a = {}
				if(!a.meen)
					a.meen =  "Chossid"
				ATZMUS.Medabeir.call(this, a)
			}
		}
	},
	Chossid: {
		get: function() {
			return ATZMUS.חסיד
		}
	},
	Afar: {
		get: function() {
			return function(a) {
				if(!a) a = {}
				a.meen = "Afar"
				
				var oi = a.Init;
				function asdf(a) {
					/*a.pashut.MishanehTziur({
						mareh:"blue"
					})*/
					/*
					
					a.AfarYetzirah.material = mat
					console.log(a.AfarYetzirah.material)
					console.log(mat.mainTexture)*/
					if(typeof(oi) == "function") 
						oi(a)
				}
				a.gameObject = "sphere"
				a.Init = asdf;
				ATZMUS.Domem.call(this,a)
			}
		}
	},
	KKK: {
		get: function() {
			return ATZMUS.חסיד
		}
	},
	Pawneemeeyoos: {
		get:function() {
			return function(gb,s) {
				var mowlth = s.mouth || s.peh,
					oymayd = s.standing || s.stand || s.oymayd,
					Sbrow1 = s.eyebrow1 || s.brow1,
					Sbrow2 = s.eyebrow2 || s.brow2,
					eye1 = s.eye1 || s.ayin1 || s.i1,
					eye2 = s.eye2 || s.ayin2 || s.i2,
					eyelid1 = s.eyelid1 || s.gawboysAyin1 || s.ilid1,
					eyelid2 = s.eyelid2 || s.gawboysAyin2 || s.ilid2,
					oyr = s.oyr || s.skin,
					gawvawn = s.gawvawn || s.color
				
				if(!window.arz) window.arz = []
				var shtarim = 0;
				var ind = 0
				var mow
				
				var mthindex = 0

				var i1, i2, ilid1, ilid2,
					brow1,
					brow2,
					b1 = 0,
					b2 = 0,
					b3 = 0,
					ix = 0, iy = 0,
					facX = 0.03,
					fac = 0.04,
					facB = 0.01,
					
					endY = -0.75,
					startY = 0,
					endX = 0.16,
					startX = -0.12,
					
					yy = 0;
					
				var a = gb, oyrOb
				
				var partzoof = {
					eyeLeft:0,
					eyelidDown:0,
					eyeRight:0,
					eyelidUp:0,
					eyebrowDown:0,
					eyebrowUp:0,
					rightEyebrowTurnUp:0,
					rightEyebrowTurnDown:0,
					leftEyebrowTurnDown:0,
					leftEyebrowTurnUp:0,
					isTalking: 0
				}
				
				this.partzoof = partzoof
				var self = this
				
				var setKiz = s.setKiz || s.setKeys ||
					s.mayftaychos || s.keys ||
					s.mawftaycheem || {}
				
				var oyrayr = s.error || s.oyrayr
				if(typeof(oyrayr) != "function")
					oyrayr = function(){}
				if(!(typeof(setKiz) == "object")) setKiz = {}
				
				oyrayr(a)
				this.peooluh = 
				function heeloochPeoola(c,v) {
					if(setKiz[c]) {
						partzoof[setKiz[c]] = v
					}
				};
				
				this.panim = 
				this.pawneem = 
				this.face = function(s,t) {
					partzoof[s] = t
				}
				
				this.cheeyoov = function(q) {
					self.peooluh(q, 1)
				}
				
				this.shleeluh = function(q) {
					self.peooluh(q, 0)
				}
				this.soychawkoys = function() {
					
					shtarim++;
					if(shtarim > 100) shtarim = 0
					
					if(mow) {
						if(!partzoof.isTalking) 
							ind = 8
						else 
							ind = (mthindex++) % 9
						
						mow
						.renderer
						.material
						.mainTexture = 
						Achdus.Tzirum.GetTexture(arz[
							ind
						])
					}
					
					
					b1 = b3 = b2 = 0;
					
		
					if(partzoof.eyeLeft) {
						if(ix < 0.16) ix += facX
					}
					if(partzoof.eyelidDown) {
						//if(yy <= -0)
						yy += fac
					}
					if(partzoof.eyeRight) {
						if(ix >= -0.12)
						ix -= facX
					}
					if(partzoof.eyelidUp) {
						//if(yy >= endY) 
						yy -= fac
					}
					
					if(partzoof.eyebrowDown) {
						b1 -= facB
					//	brow1.position.y -= facB
					}
					
					
					
					if(partzoof.eyebrowUp) {
						b1 += facB
						//brow1.position.y += facB
					}
					
					if(partzoof.rightEyebrowTurnUp) {
						b2 -= facB * 2
					}
					
					if(partzoof.rightEyebrowTurnDown) {
						b2 += facB * 2
					}
					
					if(partzoof.leftEyebrowTurnDown) {
						b3 -= facB * 2
					}
					
					if(partzoof.leftEyebrowTurnUp) {
						b3 += facB * 2
					}
					
					if(brow1)
					brow1
					.gameObject
					.transform
					.localPosition = new UnityEngine
									.Vector3(
										brow1
										.gameObject
										.transform
										.localPosition
										.x,
										brow1
										.gameObject
										.transform
										.localPosition
										.y + b1,
										brow1
										.gameObject
										.transform
										.localPosition
										.z
									)
					if(brow2) {
						brow2
						.gameObject
						.transform
						.localPosition = new UnityEngine
									.Vector3(
										brow2
										.gameObject
										.transform
										.localPosition
										.x,
										brow2
										.gameObject
										.transform
										.localPosition
										.y + b1,
										brow2
										.gameObject
										.transform
										.localPosition
										.z
									)
										
						brow2
						.gameObject
						.transform
						.localRotation
						
						= UnityEngine
						.Quaternion
						.Euler(
							brow2
							.gameObject
							.transform
							.localRotation
							.eulerAngles
							.x,
							
							brow2
							.gameObject
							.transform
							.localRotation
							.eulerAngles
							.y,
							
							brow2
							.gameObject
							.transform
							.localRotation
							.eulerAngles
							.z + b2 * 180 /	
							Math.PI
						)
					}
					
					if(brow1)
					brow1
					.gameObject
					.transform
					.localRotation
					
					= UnityEngine
					.Quaternion
					.Euler(
						brow1
						.gameObject
						.transform
						.localRotation
						.eulerAngles
						.x,
						
						brow1
						.gameObject
						.transform
						.localRotation
						.eulerAngles
						.y,
						
						brow1
						.gameObject
						.transform
						.localRotation
						.eulerAngles
						.z + b3 * 180 /	
						Math.PI
					)
					
					if(i1)
					i1
					.renderer
					.material
					.mainTextureOffset = 
					new UnityEngine.Vector2(
						ix, 0
					)
				
					if(i2)
					i2
					.renderer
					.material
					.mainTextureOffset = 
					new UnityEngine.Vector2(
						ix, 0
					)
					
					if(ilid1)
					ilid1
					.renderer
					.material
					.mainTextureOffset = 
					new UnityEngine.Vector2(
						0, yy
					)
					
					if(ilid2)
					ilid2
					.renderer
					.material
					.mainTextureOffset = 
					new UnityEngine.Vector2(
						0,yy
					)
				}
				
				mow = mowlth ? domemify(
					a.gameObject,
					mowlth
				) : null
				if(mow) {
					mow.isTrigger = true
				}
				else if(!mow) {
					oyrayr("moulth")
				}
				var n;
				for(var i = 0; i < 9; i++) {
					
					n = "well" + i
					if(!arz[n]) {
						arz.push(n)
						Achdus.Tzirum.LoadTexture(
						{
							name: n,
							url:"mouth2/mouth0" + i + ".png"
						})
					}
				}
				
				if(oyr)
				oyrOb = domemify(
					a.gameObject,
					oyr
				)
				
				if(Sbrow1)
				brow1 = domemify(
					a.gameObject,
					Sbrow1
				)
				
				if(Sbrow2)
				brow2 = domemify(
					a.gameObject,
					Sbrow2
				)
				
				if(eye1)
				i1 = domemify(
					a.gameObject,
					eye1
				)
				
				if(eye2)
				i2 = domemify(
					a.gameObject,
					eye2
				)
				
				if(eyelid1)
				ilid1 = domemify(
					a.gameObject,
					eyelid1
				)
				
				if(eyelid2)
				ilid2 = domemify(
					a.gameObject,
					eyelid2
				)
				
				if(!brow1)
					oyrayr("brow1")
					
				if(!brow2)
					oyrayr("brow2")
					
				if(!i1)
					oyrayr("i1")
					
				if(!i2)
					oyrayr("i2")
					
				if(!ilid1)
					oyrayr("ilid1")
					
				if(!ilid2)
					oyrayr("ilid2")
					
				if(!oyrOb)
					oyrayr("oyr/skin")
				
				if(mow)
				mow.renderer.
					material = new UnityEngine
								.Material(
									UnityEngine
									.Shader
									.Find(
										"Transparent/Diffuse"
									)
								)
				
				if(ilid1 && ilid2) {
					if(!ilid1.renderer
						.material
						.mainTexture) {
						
					}
					
					var oyld = ilid1.renderer
						.material
						.mainTexture
					ilid1
						.renderer
						.material = 
						
						ilid2
						.renderer
						.material =
						
						new UnityEngine
							.Material(
								UnityEngine
								.Shader
								.Find(
									"Transparent/Diffuse"
								)
							)
					
					ilid1.renderer
						.material
						.mainTexture =
					ilid2.renderer
						.material
						.mainTexture = oyld
					if(ilid1
					.renderer
					.material
					.mainTexture) {
						ilid1
						.renderer
						.material
						.mainTexture
						.wrapMode = 
						
						ilid2
						.renderer
						.material
						.mainTexture
						.wrapMode =
						
						UnityEngine
						.TextureWrapMode
						.Clamp;
					}
					
				}
				
				if(oyrOb) {
					oyrOb.renderer.
					material = new UnityEngine
								.Material(
									UnityEngine
									.Shader
									.Find(
										"Transparent/Diffuse"
									)
								)
					if(gawvawn){
					//	atzmo.changeColor(gawvawn)
					}
				}
				
			}
		}
	},
	Awvdechuh: {
		get: function() {
			return function(s) {
				if(!s) s = {}
				
				
				this.shaym = s.shaym || Date.now() + ""
				var atzmo = this
				this.changeGawvawn = this.changeColor = 
				function(ob) {
					if(oyrOb) {
						oyrOb.renderer
						.material.SetColor("_Color", new UnityEngine.Color(
							ob[0], ob[1], ob[2]
						))
					}
				}
				
				this.onawake = s.onawake 
					|| function() {}
					
				this.oncreation = s.oncreation 
					|| s.onhissHavoos
					|| function() {}
					
				this.onerror = s.onerror 
					|| function() {}
				
				this.onMawftayachUp = function(e,atz) {
					
					var it = s.onMawfatayachUp ||
					s.onkeyup ||
					s.mawftayachUp
					
					if(typeof(it) == "function") {
						it(e,atz)
					}
					
					
				}
				var setKiz = s.mawftaychoys || s.setupKeys || {}
					
				this.onMawftayachDown = function(e,atz) {
					
					var it = s.onMawfatayachDown ||
					s.onkeydown ||
					s.mawftayachDown
					
					if(typeof(it) == "function") {
						it(e,atz)
					}
				}
					
				this.mawftayachDown = function(c) {
					//if(typeof(c) == "number")
						atzmo.onMawftayachDown(c,atzmo)
						heeloochPeoola(c,1)
				}
				
				this.mawftayachUp = function(c) {
					//if(typeof(c) == "number")
						atzmo.onMawftayachUp(c,atzmo)
						heeloochPeoola(c,0)
				}
					
				function oyrayr(s) {
					if(typeof(atzmo.onerror) == "function")
						atzmo.onerror(s)
				}
				
				if(!s) s = {}
				
				
				this.zeemaynMawftaychoys =
				this.setupKeys = function(ob) {
					if(!ob) ob = {}
					if(typeof(ob) == "object")
						setKiz = ob
				}
				var choyss;
				var partzoof = {
						eyeLeft:0,
						eyelidDown:0,
						eyeRight:0,
						eyelidUp:0,
						eyebrowDown:0,
						eyebrowUp:0,
						rightEyebrowTurnUp:0,
						rightEyebrowTurnDown:0,
						leftEyebrowTurnDown:0,
						leftEyebrowTurnUp:0,
						isTalking: 0,
						moveLeft: 0,
						moveRight:0,
						moveForward:0,
						moveBackward:0,
						moveSideLeft:0,
						moveSideRight:0,
						jump:0
					}
				
				
				var a = choyss;
				this.heelooch = 
				this.walk = 
				this.move = 
				this.movement = 
				this.hawleechuh = function(s, t) {
					partzoof[s] = t
					
				}
				function heeloochPeoola(c,v) {
					if(setKiz[c]) {
						partzoof[setKiz[c]] = v
					}
					if(partzoof.moveRight) {
						choyss
						.myInput
						.SetAxis("Horizontal", 1)
					}
					
					else if(partzoof.moveLeft) {
						choyss
						.myInput
						.SetAxis("Horizontal", -1)
					}
					else
						choyss
						.myInput
						.SetAxis("Horizontal", 0)
						
					if(partzoof.moveForward) {
						choyss
						.myInput
						.SetAxis("Vertical", -1)
					} else if(partzoof.moveBackward) {
						choyss
						.myInput
						.SetAxis("Vertical", 1)
					} else
						choyss
						.myInput
						.SetAxis("Vertical", 0)
					
					if(partzoof.moveSideRight) {
						choyss
						.myInput
						.SetAxis("Strife", -1)
					} else if(partzoof.moveSideLeft) {
						choyss
						.myInput
						.SetAxis("Strife", 1)
					} else
						choyss
						.myInput
						.SetAxis("Strife", 0)
						
					if(partzoof.jump) {
						choyss
						.myInput
						.SetAxis("Jump", 1)
					} else {
						choyss
						.myInput
						.SetAxis("Jump", 0)
					}
				}
				this.panim = 
				this.pawneem = 
				this.face = function(s,t) {
					partzoof[s] = t
				}
				var mowlth = s.mouth || s.peh,
				oymayd = s.standing || s.stand || s.oymayd,
				Sbrow1 = s.eyebrow1 || s.brow1,
				Sbrow2 = s.eyebrow2 || s.brow2,
				eye1 = s.eye1 || s.ayin1 || s.i1,
				eye2 = s.eye2 || s.ayin2 || s.i2,
				eyelid1 = s.eyelid1 || s.gawboysAyin1 || s.ilid1,
				eyelid2 = s.eyelid2 || s.gawboysAyin2 || s.ilid2,
				oyr = s.oyr || s.skin,
				gawvawn = s.gawvawn || s.color,
				goof = s.goof || s.body || s.model
				var makom = s.makom || s.position || {
					x:0,y:0,z:0
				}
				
				var shtarim = 0;
				var ind = 0
				var mow
				
				var mthindex = 0

				var i1, i2, ilid1, ilid2,
					brow1,
					brow2,
					b1 = 0,
					b2 = 0,
					b3 = 0,
					ix = 0, iy = 0,
					facX = 0.03,
					fac = 0.04,
					facB = 0.01,
					
					endY = -0.75,
					startY = 0,
					endX = 0.16,
					startX = -0.12,
					
					yy = endY + 0.1;

					
				Object.defineProperties(this, {
					name: {
						get: function() {
							return choyss.name
						}
					}
				})
				var a;
				var oyrOb
				choyss = new Achdus.Chai({
					name: atzmo.shaym,
					position: makom,
					Init: function(a) {
						
						//a.gameObject.tag = "Player"
						if(typeof(atzmo.onawake) == "function")
							atzmo.onawake(a)
							
						
					},
					FixedUpdate: function(a) {
						
						
						shtarim++;
						if(shtarim > 100) shtarim = 0
						
						/*a
						.myInput
						.SetAxis("Vertical", 0)
						
						a
						.myInput
						.SetAxis("Strife", 0)
						
						a
						.myInput
						.SetAxis("Horizontal", 0)
						*/
						
						
						if(mow) {
							if(!partzoof.isTalking) 
								ind = 8
							else 
								ind = (mthindex++) % 9
							
							mow
							.renderer
							.material
							.mainTexture = 
							Achdus.Tzirum.GetTexture(arz[
								ind
							])
						}
						
						
						b1 = b3 = b2 = 0;
						
						if(typeof(atzmo.oncreation) == "function")
							atzmo.oncreation(a)
							
						if(partzoof.eyeLeft) {
							if(ix < 0.16) ix += facX
						}
						if(partzoof.eyelidDown) {
							if(yy <= -0)
							yy += fac
						}
						if(partzoof.eyeRight) {
							if(ix >= -0.12)
							ix -= facX
						}
						if(partzoof.eyelidUp) {
							if(yy >= endY) 
							yy -= fac
						}
						
						if(partzoof.eyebrowDown) {
							b1 -= facB
						//	brow1.position.y -= facB
						}
						
						
						
						if(partzoof.eyebrowUp) {
							b1 += facB
							//brow1.position.y += facB
						}
						
						if(partzoof.rightEyebrowTurnUp) {
							b2 -= facB * 2
						}
						
						if(partzoof.rightEyebrowTurnDown) {
							b2 += facB * 2
						}
						
						if(partzoof.leftEyebrowTurnDown) {
							b3 -= facB * 2
						}
						
						if(partzoof.leftEyebrowTurnUp) {
							b3 += facB * 2
						}
						
						if(brow1)
						brow1
						.gameObject
						.transform
						.localPosition = new UnityEngine
										.Vector3(
											brow1
											.gameObject
											.transform
											.localPosition
											.x,
											brow1
											.gameObject
											.transform
											.localPosition
											.y + b1,
											brow1
											.gameObject
											.transform
											.localPosition
											.z
										)
						if(brow2) {
							brow2
							.gameObject
							.transform
							.localPosition = new UnityEngine
										.Vector3(
											brow2
											.gameObject
											.transform
											.localPosition
											.x,
											brow2
											.gameObject
											.transform
											.localPosition
											.y + b1,
											brow2
											.gameObject
											.transform
											.localPosition
											.z
										)
											
							brow2
							.gameObject
							.transform
							.localRotation
							
							= UnityEngine
							.Quaternion
							.Euler(
								brow2
								.gameObject
								.transform
								.localRotation
								.eulerAngles
								.x,
								
								brow2
								.gameObject
								.transform
								.localRotation
								.eulerAngles
								.y,
								
								brow2
								.gameObject
								.transform
								.localRotation
								.eulerAngles
								.z + b2 * 180 /	
								Math.PI
							)
						}
						
						if(brow1)
						brow1
						.gameObject
						.transform
						.localRotation
						
						= UnityEngine
						.Quaternion
						.Euler(
							brow1
							.gameObject
							.transform
							.localRotation
							.eulerAngles
							.x,
							
							brow1
							.gameObject
							.transform
							.localRotation
							.eulerAngles
							.y,
							
							brow1
							.gameObject
							.transform
							.localRotation
							.eulerAngles
							.z + b3 * 180 /	
							Math.PI
						)
						
						if(i1)
						i1
						.renderer
						.material
						.mainTextureOffset = 
						new UnityEngine.Vector2(
							ix, 0
						)
					
						if(i2)
						i2
						.renderer
						.material
						.mainTextureOffset = 
						new UnityEngine.Vector2(
							ix, 0
						)
						
						if(ilid1)
						ilid1
						.renderer
						.material
						.mainTextureOffset = 
						new UnityEngine.Vector2(
							0, yy
						)
						
						if(ilid2)
						ilid2
						.renderer
						.material
						.mainTextureOffset = 
						new UnityEngine.Vector2(
							0,yy
						)
					},
					model: goof
					//model: "ok22.gltf"
				})
				
				this.choyss = choyss
			}
		}
	}
	
})
})();
function ATZMUS() {
	
}


function tzeeorify(domem, x, y) {
	domem.renderer.material.mainTextureOffset = 
	new UnityEngine.Vector2(
		x, y
	)
}
function yacheedify(domem, shaym) {
	var oy = domemify(
		domem.gameObject,
		shaym
	)
	if(oy) {
		oy.renderer.material.mainTexture
		.wrapMode = 
		UnityEngine
		.TextureWrapMode
		.Clamp
		
	}
	return oy
}

function toyhar(lid, cl) {
	if(lid) {
		var tax = 
		lid.renderer
		.material
		.mainTexture
		
		lid
		.renderer
		.material = 
		new UnityEngine.Material(
			UnityEngine.Shader.Find(
				"Transparent/Diffuse"
			)
		)
		
		lid.renderer
			.material
			.mainTexture = tax
			
		if(cl) {
			lid
			.renderer
			.material
			.mainTexture
			.wrapMode =
			UnityEngine
			.TextureWrapMode
			.Clamp
		}
		
	}
}
function hisslawblooysh(k, oyr, str) {
	return hisslawbish(k, domamtee(
		oyr, str
	))
}


function hisslawbish(k, toyfill) {
	if(!k || !toyfill) return n;
	
	k.gameObject.transform.position = 
	toyfill.gameObject.transform.position
	
	k.gameObject.transform.rotation = 
	toyfill.gameObject.transform.rotation
	
	k.gameObject.transform.localScale = 
	toyfill.gameObject.transform.lossyScale
	
	k.gameObject.transform.SetParent( 
		toyfill.gameObject.transform
	)
	return toyfill;
}



function makom(d, x, y, z) {
	if(d) {
		var x1 = 0, 
			y1 = 0, 
			z1 = 0
		if(typeof(x) == "number") {
			x1 = x
		}
		if(typeof(y) == "number") {
			y1 = y
		}
		if(typeof(z) == "number") {
			z1 = z
		}
		d
		.gameObject
		.transform
		.localPosition = 
		new UnityEngine
		.Vector3(
			d
			.gameObject
			.transform
			.localPosition
			.x + 
			x1,
			d
			.gameObject
			.transform
			.localPosition
			.y + 
			y1,
			d
			.gameObject
			.transform
			.localPosition
			.z + 
			z1
			
		)
	}
}
function makom(d, x, y, z) {
	if(d) {
		var x1 = 0, 
			y1 = 0, 
			z1 = 0
		if(typeof(x) == "number") {
			x1 = x
		}
		if(typeof(y) == "number") {
			y1 = y
		}
		if(typeof(z) == "number") {
			z1 = z
		}
		d
		.gameObject
		.transform
		.localPosition = 
		new UnityEngine
		.Vector3(
			d
			.gameObject
			.transform
			.localPosition
			.x + 
			x1,
			d
			.gameObject
			.transform
			.localPosition
			.y + 
			y1,
			d
			.gameObject
			.transform
			.localPosition
			.z + 
			z1
			
		)
	}
}

function seaboov(d, x, y, z) {
	if(d) {
		var x1 = 0, 
			y1 = 0, 
			z1 = 0
		if(typeof(x) == "number") {
			x1 = x
		}
		if(typeof(y) == "number") {
			y1 = y
		}
		if(typeof(z) == "number") {
			z1 = z
		}
		d
		.gameObject
		.transform
		.eulerAngles = 
		UnityEngine
		.Quaternion
		.Euler(
			d
			.gameObject
			.transform
			.eulerAngles
			.x + 
			x1,
			d
			.gameObject
			.transform
			.eulerAngles
			.y + 
			y1,
			d
			.gameObject
			.transform
			.eulerAngles
			.z + 
			z1
			
		)
	
	}
}

function kawmoys(d, x, y, z) {
	if(d) {
		var x1 = 0, 
			y1 = 0, 
			z1 = 0
		if(typeof(x) == "number") {
			x1 = x
		}
		if(typeof(y) == "number") {
			y1 = y
		}
		if(typeof(z) == "number") {
			z1 = z
		}
		d
		.gameObject
		.transform
		.localScale = 
		new UnityEngine
		.Vector3(
			d
			.gameObject
			.transform
			.localScale
			.x + 
			x1,
			d
			.gameObject
			.transform
			.localScale
			.y + 
			y1,
			d
			.gameObject
			.transform
			.localScale
			.z + 
			z1
			
		)
	}
}
function tziruf(d,x,y) {
	if(d) {
		var x1 = 0,
			y1 = 0
		if(typeof(x) == "number")
			x1 = x
		if(typeof(x) == "number")
			y1 = y
			
		return d
		.renderer
		.material
		.mainTextureOffset = 
		new UnityEngine.Vector2(
			x1, 
			y1
		)
		
	}
	return null;
}
function domamtee(d, name) {
	var d =  domemify(d.gameObject,name)
/*	if(d && tr) {
		toyhar(d)
	}*/
	return d
}
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

function setAv(dm1, dm2, nm) {
	var tr =  findDeepTransform(
		dm2.gameObject.transform, nm
	)
	if(tr) {
		
		dm1
		.gameObject
		.transform
		.position = tr.position;
		
		dm1
		.gameObject
		.transform
		.rotation = tr.rotation;
		
		
		dm1
		.gameObject
		.transform
		.SetParent(
			tr
		)
	}
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
var f32 = Achdus.Yisayruh.float32()
f32[0] = 0
f32[1] = 1
f32[2] = -1

