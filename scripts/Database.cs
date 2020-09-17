using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Database : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Ok d = new Ok(8, Application.dataPath + "/ok.txt");
	/*	Debug.Log(d.RibuaRoshaKamos);
		Debug.Log(d.RibuaContentKamos);
		Debug.Log(d.RibuaKamos);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Ok : OyRibuaOtzar {
//	public System.IO.FileStream str;
	public int curLength = 0;
	public string path;
	public int RibuaRoshaKamos {
		get;
	}
	
	public int RibuaContentKamos {
		get;
	}
	
	public int RibuaKamos {
		get {
				return (
					this.RibuaRoshaKamos + 
					this.RibuaContentKamos
				);
		}
	}
	
	public OyRibua Chapaysh(uint ribuaId) {
		Ko c = new Ko();
		
		return c;
	}
	
	public OyRibua BoreiChadash() {
		Ko c = new Ko();
	/*Lo	byte[] bts = new byte[RibuaKamos+curLength];
	/*	byte[] bts = new byte[RibuaKamos+curLength];
		var str = new System.IO
			.FileStream(
				path,
				System
				.IO
				.FileMode
				.Read
			);
		/*
		str.Write(
			bts, 
			2, 
			bts.Length - 2
		);
		byte[] rd = new byte[6];
		str.Read(rd, 0, 5);
		Debug.Log(rd);
		str.Flush(true);
		str.Close();
		curLength += bts.Length;*/
		return c;
	}
	
	public Ok(int s, string path) {
		this.RibuaRoshaKamos = 256;
		this.RibuaContentKamos = 128 * s - RibuaRoshaKamos;
		this.path = path;
	//	Debug.Log(System.IO.FileMode.toString());
		BoreiChadash();
		BoreiChadash();
		
	}
}

public class Ko : OyRibua {
	
	public uint Mafteiach {
		get;
	}
	
	public long KachRosha(int sadeh) {
		
		return 0;
	}
	
	public void MunachRosha(int sadeh, long erech) {
		
	}
	
	public void Korei(byte[] tach, int tachOffset, int makorOffset, int Minuy) {
		
	}
	
	public void Kosayv(byte[] tach, int tachOffset, int makorOffset, int Minuy) {
		
	}
	
	public void Dispose() {
		
	}
	public Ko() {
		
	}
}

public interface OyRibuaOtzar {
	
	int RibuaContentKamos {
		get;
	}
	
	int RibuaRoshaKamos {
		get;
	}
	//multiple of 1288, total size
	int RibuaKamos {
		get;
	}
	
	OyRibua Chapaysh(uint ribuaId);
	OyRibua BoreiChadash ();
}

public interface OyRibua : IDisposable {
	uint Mafteiach {
		get;
	}
	
	long KachRosha(int sadeh);
	
	void MunachRosha(int sadeh, long erech);
	void Korei(byte[] tach, int tachOffset, int makorOffset, int Minuy);
	void Kosayv(byte[] makor, int makorOffset, int tachOffset, int Minuy);
}

public interface OyKoysavOtzar {
	void Hishaveh(uint koyseivMafteiach, byte[] divarim);
	
	byte[] Chapaysh (uint koyseivMafteiach);
	
	uint Borei();
	
	uint Borei(byte[] divarim);
	
	uint Borei(Func<uint, byte[]> divarimHishavus);
	
	uint Batail (uint koyseivMafteiach);
}

public interface OyMafteiach<M, D> {
	void Munach(M mafteiach, D davar);
	
	Tuple<M, D> Kach(M mafteiach);
	
	IEnumerable<Tuple<M, D>> GadolMiOShavehLi(M mafteiach);
	
	IEnumerable<Tuple<M, D>> GadolMi(M mafteiach);
	
	IEnumerable<Tuple<M, D>> KatanMiOShavehLi(M mafteiach);
	
	IEnumerable<Tuple<M, D>> KatanMi(M mafteiach);
	
	bool Batail (M mafteiach, D davar, IComparer<D> davarMoznaim = null);
	
	bool Batail (M mafteiach);
}