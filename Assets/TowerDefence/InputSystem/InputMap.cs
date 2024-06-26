//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/TowerDefence/InputSystem/InputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""id"": ""bed047ea-c178-4774-b6cd-b1a0734af34a"",
            ""actions"": [
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""46ae0cb0-6890-48d3-9735-eebfca7ad365"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseSwipe"",
                    ""type"": ""Button"",
                    ""id"": ""afdd9b97-edd8-4bdb-a1e1-763113e43a13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""38c360cb-12c7-44ad-aeaf-182868391de9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseSwipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2b92279-b836-4d62-ac62-ce65a32326ff"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyboardAndMouse
        m_KeyboardAndMouse = asset.FindActionMap("KeyboardAndMouse", throwIfNotFound: true);
        m_KeyboardAndMouse_MouseDelta = m_KeyboardAndMouse.FindAction("MouseDelta", throwIfNotFound: true);
        m_KeyboardAndMouse_MouseSwipe = m_KeyboardAndMouse.FindAction("MouseSwipe", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // KeyboardAndMouse
    private readonly InputActionMap m_KeyboardAndMouse;
    private List<IKeyboardAndMouseActions> m_KeyboardAndMouseActionsCallbackInterfaces = new List<IKeyboardAndMouseActions>();
    private readonly InputAction m_KeyboardAndMouse_MouseDelta;
    private readonly InputAction m_KeyboardAndMouse_MouseSwipe;
    public struct KeyboardAndMouseActions
    {
        private @InputMap m_Wrapper;
        public KeyboardAndMouseActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseDelta => m_Wrapper.m_KeyboardAndMouse_MouseDelta;
        public InputAction @MouseSwipe => m_Wrapper.m_KeyboardAndMouse_MouseSwipe;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardAndMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardAndMouseActions set) { return set.Get(); }
        public void AddCallbacks(IKeyboardAndMouseActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces.Add(instance);
            @MouseDelta.started += instance.OnMouseDelta;
            @MouseDelta.performed += instance.OnMouseDelta;
            @MouseDelta.canceled += instance.OnMouseDelta;
            @MouseSwipe.started += instance.OnMouseSwipe;
            @MouseSwipe.performed += instance.OnMouseSwipe;
            @MouseSwipe.canceled += instance.OnMouseSwipe;
        }

        private void UnregisterCallbacks(IKeyboardAndMouseActions instance)
        {
            @MouseDelta.started -= instance.OnMouseDelta;
            @MouseDelta.performed -= instance.OnMouseDelta;
            @MouseDelta.canceled -= instance.OnMouseDelta;
            @MouseSwipe.started -= instance.OnMouseSwipe;
            @MouseSwipe.performed -= instance.OnMouseSwipe;
            @MouseSwipe.canceled -= instance.OnMouseSwipe;
        }

        public void RemoveCallbacks(IKeyboardAndMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboardAndMouseActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyboardAndMouseActions @KeyboardAndMouse => new KeyboardAndMouseActions(this);
    public interface IKeyboardAndMouseActions
    {
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnMouseSwipe(InputAction.CallbackContext context);
    }
}
