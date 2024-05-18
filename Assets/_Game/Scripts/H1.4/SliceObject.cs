using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;

public class SliceObject : MonoBehaviour
{
    public Transform starSlicePoint;
    public Transform endSlicePoint;
    public Material crossSectionMareial;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;
    public float curForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(starSlicePoint.position, endSlicePoint.position,out RaycastHit hit,sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - starSlicePoint.position, velocity);
        planeNormal.Normalize();
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);
        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMareial);
            SetupSlice(upperHull);
            GameObject loverHull = hull.CreateLowerHull(target,crossSectionMareial);
            SetupSlice(loverHull);

            Destroy(target);
        }
    }

    public void SetupSlice(GameObject slicedObjet)
    {
        Rigidbody rb = slicedObjet.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObjet.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(curForce, slicedObjet.transform.position, 1);
    }
}
