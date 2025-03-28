Extensions for FMOD plugin
- Method chain workflow
- C# method naming (PascalCase)

```csharp
[SerializeField] EventReference eventRef;
    
void PlaySoundDefault()
{
    EventInstance inst = RuntimeManager.CreateInstance(eventRef);
    inst.setParameterByName("ParamA", 1f);
    inst.setParameterByNameWithLabel("ParamB", "Value");
    inst.set3DAttributes(transform.To3DAttributes());
    RuntimeManager.AttachInstanceToGameObject(inst, gameObject, true);
    inst.setVolume(.5f);
    inst.start();
    inst.release();

    inst.getPaused(out bool result);
    if(result)
        inst.setPaused(false);
    
    if (inst.isValid())
        inst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
}

void PlaySoundExtensions()
{
    EventInstance inst = eventRef.Create()
        .SetParameter("ParamA", 1f)
        .SetParameter("ParamB", "Value")
        .Set3D(transform)
        .AttachToGameObject(gameObject)
        .SetVolume(.5f)
        .Play();

    if (inst.IsPaused())
        inst.Resume();
    
    inst.TryStop();
}
```
