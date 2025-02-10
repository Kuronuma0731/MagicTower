using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//People
public class Peoples : MonoBehaviour
{
    [SerializeField] private string characterName; // ����W��
    [SerializeField] private int hp;              // ��q
    [SerializeField] private int attackPower;     // �����O
    [SerializeField] private int defense;         // ���m�O

    public string CharacterName => characterName;
    public int HP { get => hp; set => hp = value; }
    public int AttackPower => attackPower;
    public int Defense => defense;

    public bool IsDead => HP <= 0;

    // �����޿�
    public int TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(0, damage - Defense);
        HP -= actualDamage;
        return actualDamage;
    }
    //[SerializeField] public int HP { get; set; }
    //[SerializeField] public int AttackPower { get; set; }
    //[SerializeField] public int Defense { get; set; }
    //[SerializeField] public int Agile { get; set; }
    //[SerializeField] public int ExperienceValue { get; set; }
    //[SerializeField] public int NumberOfAttacks { get; set; }
    //// �s�W���`�ݩ�
    //[SerializeField] public bool IsDead { get; private set; } = false;
    //public virtual void CheckHealth()
    //{
    //    if (HP <= 0)
    //    {
    //        IsDead = true;
    //        OnDeath();
    //    }
    //}
    //public virtual void PrintStats()
    //{
    //    Debug.Log($"HP: {HP}, Attack: {AttackPower}, Defense: {Defense}, Agile: {Agile}, Experience: {ExperienceValue}, Number of Attacks: {NumberOfAttacks}");
    //}
    //public virtual void OnDeath()
    //{
    //
    //}
    //
    //public virtual void Die()
    //{
    //    throw new NotImplementedException();
    //}
    // �ˬd�ͩR��

}
