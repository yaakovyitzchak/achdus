//B"H
//var ATZMUS = {}
var isawch = window.Achdus 
			&& window.importNamespace
			&& window.System
var q = []
var wrld,fiz = [];		
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
		var slf = this
		var rotation = r || mt()
		var position = p || mt()
		var scale = s || mt(1)
		var sl = this
		this.Find = function(s) {
		
		}
		
		this.eulerAngles = new function() {
			
		}
		this.childCount = 0
		this.gameObject = {}
		this.GetChild = function(s) {
			
		}
		var rad = Math.PI / 180
		var deg = 180 * Math.PI
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
					"xyz".split("")
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
				//y * PI / 180 = x
				//x * 180 = y * PI
				//x * 180 / PI = y
			},
			eulerAngles: {
				get: function() {
					return {
						x: slf.rotation.x 
						* 180 / Math.PI
						,
						y: slf.rotation.y 
						* 180 / Math.PI
						,
						z: slf.rotation.z 
						* 180 / Math.PI
					}
				},
				set: function(v) {
					"xyz".split("")
					.forEach(function(r) {
						
						if(typeof(v[r]) == "number") {
							rotation[r] = v[r]
								* rad
							if(sl.gameObject._pushit) {
								
								sl
								.gameObject
								._pushit
								.rotation[r] = v[r]
								* rad
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
					"xyz".split("")
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
			},
			localScale: {
				get: function() {
					return scale
				},
				set: function(v) {
					"xyz".split("")
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
		
		this.Renderer = function() {
			
		}
		
		this.GameObject = function(n) {
			this.name = n
			this.type = "GameOy"
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
	var ayind = false
	function doQ() {
		
		if(!isawch) {
			
			q.forEach(function(w) {
				w.onCreate()
			})
			
			q.forEach(function(w) {
				w.onMawchar()
			})
		/*	
			ATZMUS
			.ikarAyin
			.gameObject.
			_pushit = wrld["ayin"]
			
			*/
			Achdus
			.Yaakov
			.mainCoby
			.ikarAyin
			.mishawnehGoof("ayin")
			
			ATZMUS.ikarAyin.position.z = 5
			ayind = true
			
			
			
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
				
				ml = a.woy,
				mtt = a.empty,
				gob = a.gameObject,
				rnd = new UnityEngine.Renderer()
		
			if(typeof(gob) == "string") {
				this.gameObject = g(gob)
			} else {
				this.gameObject = new UnityEngine.GameObject();
			}
			
			function g(s) {
				switch(s) {
					case "empty": 
					mtt=true
					console.log("OK",mtt)
					return new UnityEngine.GameObject();
					break;
					default: 
					return new UnityEngine.GameObject();
					
				}
				
			
			}
			
			Object.defineProperties(this, {
				renderer: {
					get: function(a) {
						return rnd
					},
					set: function(v) {
						
					}
				},
				color: {
					get: function(a) {
						return c
					},
					set: function(v) {
						c = v
						if(doy._push) {
							doy._push.color = v
						}
					}
				}
			})
			
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
			
			this.onMawchar = function() {
				
			}
			
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
				
				oy.tzurah = {
					type:"lambert",
					arguments: [
						{
							color: "white"
						}
					]
				}
				
				
				if(typeof(c) == "string") {
					
						oy.tzurah.arguments= [
							{
								color: c
							}
						]
					
					
				}
				var asdf = _p || ml
				if(typeof(asdf) == "string") {
					
					doy._push = wrld[asdf]
				} else {
					if(gob == "empty")
						oy.empty = true
					if(
						typeof(gob) == "object" 
						&& gob.type == "GameOy"
					//	&& gob.constructor.name == "GameObject"
					) {
						doy.gameObject = gob
					} else {
					//	doy._push = gob._pushit
					// {
						doy._push = new YICHOYLISS.Nivra(oy)
						
						doy._push.on("hissHavoos", function() {
							if(typeof(fx) == "function")
								fx(doy)
						})
						
						wrld.hoyseef(doy._push)
						doy.gameObject._pushit = doy._push

					}
				}
				
				
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
				console.log(doy.gameObject, 2)
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
					_pushit: "ayin"
				})
				
			}
		}
	}
	
	
	function gawshmeeoos() {
	
		const PhysX = PHYSX({
		  locateFile: function(path) {
			if (path.endsWith('.wasm')) {
			  return YICHOYLISS.oytzayr["kayleem/iu"]
			}
			return path
		  }
		})

		let resolve
		const promise = new Promise(function(res) {
		  return resolve = res
		})

		PhysX.ready = function() {
			return promise
		}
		PhysX.onRuntimeInitialized = function() {
		  PhysX.loaded = true
		  return resolve()
		}

		window.PhysX = PhysX

		// Usage

		PhysX.ready().then(function () {
		  console.log('Boruch Hashem!!')
		  const filterData = new PhysX.PxFilterData(0, 0, 0, 0)
		  
		  //
		  
		var v = PhysX.PX_PHYSICS_VERSION
		var dec = new PhysX.PxDefaultErrorCallback()
		var al = new PhysX.PxDefaultAllocator()
		var fn = PhysX.PxCreateFoundation(
			v, al, dec
		)

		var tcb = {
			onContactBegin: () => {},
			onContactEnd: () => {},
			onContactPersist: () => {},
			onTriggerBegin: () => {},
			onTriggerEnd: () => {}
		}

		var pInst = PhysX.PxSimulationEventCallback
		.implement(tcb)

		gawsh = PhysX
		.PxCreatePhysics(
			v, fn, 
			new PhysX
				.PxTolerancesScale(),
			false, null
		)

		PhysX
		.PxInitExtensions(gawsh, null)

		var mawkomD = PhysX
		.getDefaultSceneDesc(
			gawsh.getTolerancesScale(),
			0,
			pInst
		)

		mawkoym = gawsh
			.createScene(mawkomD)
		
		wrld.on("hissHavoos", function(){
			mawkoym.simulate(1 / 60, true)
			mawkoym.fetchResults(true)
			fiz.forEach(x => x());
		})
		
		
		doQ();
		

		

		})
	}
	/*window.defineProperties({
		importNamespace: {
			get: function() {
				
			}
		}
	})*/
}
window.addEventListener("load", function(m) {
	gawshmeeoos()
	
	
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


var coym,it;


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
				var self = this;
				var ms = a.meen,
					neef = a.Neefgash
				if(typeof(ms) != "string") 
					ms = "Domem"
				var fncs = {}
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
				deef(self)
				
				self.on(a)
				
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
								ms == "Tzomayach")
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
					
					if(neef) {
						oyb.Neefgash = neef
					}
					
					if(a.color) {
						oyb.color = a.color
						
					}
					
					if(a.texture) {
						oyb.texture = a.texture
						
					}
					
					if(a.TriggerEnter) {
						oyb.TriggerEnter = a.TriggerEnter
						
					}
					
					if(a.position) {
						oyb.position = a.position
					}
					
					if(a.rotation) {
						oyb.rotation = a.rotation
					}
					
					if(a.scale) {
						oyb.scale = a.scale
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
					
					if(typeof(goof) == "string") {
						oyb.model = goof;
					}
					
					var pashut = new Achdus[
							ms
						](oyb);
					
					
				}
				
				function deef(that) {
					Object.defineProperties(
					that, 
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
							on: {
								get: function() {
									return function(oyb) {
										ups.forEach(function(x) {
											if(
												typeof(
													oyb[x[1]]
												) == "function"
											) {
												if(!fncs[x[0]]) 
													fncs[x[0]] = []
												fncs[x[0]].push(oyb[x[1]])
											}
										})
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
						mx, my,
						dx = 0,dz = 0,
						sp = 3
					coym = new ATZMUS.Domem({
						gameObject: it.gameObject,
						HissHavoos: function(a) {
							if(tawr) {
								if(ATZMUS.mawftaychoys[114])
									dz -= sp
								if(ATZMUS.mawftaychoys[102])
									dz += sp
							/*	if(ATZMUS.mawftaychoys[116])
									dx -= sp
								if(ATZMUS.mawftaychoys[103])
									dx += sp
							*/
								mx = Achdus
									.Input
									.GetAxis("Mouse X")
								my = Achdus
									.Input
									.GetAxis("Mouse Y")
							
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
					
					if(!a.rooch) {   
						self.on({
							heesscheel(b) {
								var gm = new PhysX.PxBoxGeometry(
									self.scale.x / 2,
									self.scale.y / 2,
									self.scale.z / 2
								)

								var mat = gawsh.createMaterial(0.2,0.2,0.2)

								var neeseem = new PhysX.PxShapeFlags(
									PhysX.PxShapeFlag.eSCENE_QUERY_SHAPE.value |
									PhysX.PxShapeFlag.eSIMULATION_SHAPE.value
								)

								var tzooruh = gawsh.createShape(
									gm, mat, false, neeseem
								)

								var coyrdz = {
									rotation: {
										w: 1,
										x: self.rotation.x, 
										y: self.rotation.y, 
										z: self.rotation.z
									},
									translation: {
										x: self.position.x, 
										y: self.position.y, 
										z: self.position.z
									}
								}

								var goof;
								
								if(!a.mihawlach) {
									goof = gawsh
										.createRigidStatic(coyrdz)
								} else {
									goof = gawsh
										.createRigidDynamic(
										coyrdz
									)
								}
								
									
								
								goof.attachShape(tzooruh)
								
								mawkoym.addActor(goof, null)
								self.goofGawshmee = goof
								fiz.push(() => {
									/*
										4635
										0535
										0655
										4389
										
										06/24
										
										200
										
										
										18002408100
										
										
									*/
								//	
									var tr = goof.getGlobalPose()
									b.position.x = 
									tr.translation.x
									
									b.position.y = 
									tr.translation.y

									
									b.position.z = 
									tr.translation.z

									
									b.rotation.x = 
									tr.rotation.x
									
									b.rotation.y = 
									tr.rotation.y

									b.rotation.z = 
									tr.rotation.z
								})
								/*self.on({
									HissHavoos(a) {
										
									}
								})*/
							}
						})
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
								}
							}
						},
						hawlaym: {
							get: function() {
								return function(hl) {
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
								})
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