using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public static class FMODExtensions
{
    public static EventInstance Create(this EventReference eventRef)
    {
        return RuntimeManager.CreateInstance(eventRef);
    }

    public static bool IsValid(this EventInstance inst)
    {
        return inst.isValid();
    }

    public static bool IsPaused(this EventInstance inst)
    {
        inst.getPaused(out bool result);
        return result;
    }
    
    public static EventInstance Start(this EventInstance inst)
    {
        inst.start();
        return inst;
    }

    public static EventInstance Play(this EventInstance inst)
    {
        inst.start();
        inst.release();
        return inst;
    }

    public static EventInstance Stop(this EventInstance inst)
    {
        inst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        return inst;
    }

    public static EventInstance TryStop(this EventInstance inst)
    {
        if (inst.isValid())
            inst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        return inst;
    }
    
    public static EventInstance StopImmediate(this EventInstance inst)
    {
        inst.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        return inst;
    }
    
    public static EventInstance Pause(this EventInstance inst)
    {
        inst.setPaused(true);
        return inst;
    }
    
    public static EventInstance Resume(this EventInstance inst)
    {
        inst.setPaused(false);
        return inst;
    }

    public static EventInstance Set3D(this EventInstance inst, Vector3 value)
    {
        inst.set3DAttributes(value.To3DAttributes());
        return inst;
    }
    
    public static EventInstance Set3D(this EventInstance inst, Transform target)
    {
        inst.set3DAttributes(target.To3DAttributes());
        return inst;
    }

    public static EventInstance SetParameter(this EventInstance inst, string name, float value, bool ignoreSeekSpeed = false)
    {
        inst.setParameterByName(name, value, ignoreSeekSpeed);
        return inst;
    }

    public static EventInstance SetParameter(this EventInstance inst, string name, string value, bool ignoreSeekSpeed = false)
    {
        inst.setParameterByNameWithLabel(name, value, ignoreSeekSpeed);
        return inst;
    }

    public static EventInstance SetParameter(this EventInstance inst, PARAMETER_ID name, float value, bool ignoreSeekSpeed = false)
    {
        inst.setParameterByID(name, value, ignoreSeekSpeed);
        return inst;
    }

    public static EventInstance SetParameter(this EventInstance inst, PARAMETER_ID name, string value, bool ignoreSeekSpeed = false)
    {
        inst.setParameterByIDWithLabel(name, value, ignoreSeekSpeed);
        return inst;
    }

    public static EventInstance SetVolume(this EventInstance inst, float volume)
    {
        inst.setVolume(volume);
        return inst;
    }
    
    public static EventInstance AttachToGameObject(this EventInstance inst, GameObject target)
    {
        RuntimeManager.AttachInstanceToGameObject(inst, target, true);
        return inst;
    }
    
    public static EventInstance AttachToGameObject(this EventInstance inst, GameObject target, Rigidbody rb)
    {
        RuntimeManager.AttachInstanceToGameObject(inst, target, rb);
        return inst;
    }
    
    public static EventInstance AttachToGameObject(this EventInstance inst, GameObject target, Rigidbody2D rb)
    {
        RuntimeManager.AttachInstanceToGameObject(inst, target, rb);
        return inst;
    }

    public static EventInstance SetSpace(this EventInstance inst, AudioSpace audioSpace)
    {
        const string Space = "Space";
        return inst.SetParameter(Space, audioSpace.ToString());
    }

    public static VCA SetVolume(this VCA vca, float volume)
    {
        vca.setVolume(volume);
        return vca;
    }
    
    public enum AudioSpace
    {
        space2D,
        space3D
    }
}