package md5499c748c61604ba11fa249d26fea76c1;


public class DetailsView
	extends md5c293e307133ee8f46151deed2480c6a8.MvxActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Notebook.Droid.Views.DetailsView, Notebook.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DetailsView.class, __md_methods);
	}


	public DetailsView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DetailsView.class)
			mono.android.TypeManager.Activate ("Notebook.Droid.Views.DetailsView, Notebook.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
