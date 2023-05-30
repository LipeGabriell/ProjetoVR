//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectController : MonoBehaviour
{

    public Material InactiveMaterial;

    public Material GazedAtMaterial;

    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 100f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private const float tempo = 3f;

    [SerializeField] private GameObject player;

    private Renderer _myRenderer;
    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    private void Update()
    {
    }

    IEnumerator Andar()
    {
        yield return new WaitForSeconds(tempo);
        player.transform.position = this.transform.position;
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }
    public void OnPointerExit()
    {
        SetMaterial(false);
        StopCoroutine(Andar());
    }

    public void OnPointerClick()
    {
        Console.WriteLine("Clickou");
        StartCoroutine(Andar());
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
