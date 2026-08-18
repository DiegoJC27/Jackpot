using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CombatStateMachine : MonoBehaviour
{
    public CombatState CurrentState => m_CurrentState;
    private CombatState m_CurrentState;
    public CombatManager CombatManager => m_CombatManager;
    [SerializeField] private CombatManager m_CombatManager;
    public PlayerManager Player => m_Player;
    [SerializeField] private PlayerManager m_Player;
    public EnemyManager Enemy => m_Enemy;
    [SerializeField] private EnemyManager m_Enemy;

    private CombatPhase combatPhase;
    private EnemyPhase enemyPhase;
    private BegginingPhase begginingPhase;
    private MainPhase mainPhase;
    private EndPhase endPhase;
    private CombatEndPhase combatEndPhase;
    private void Awake()
    {
        combatPhase = new CombatPhase(this);
        enemyPhase = new EnemyPhase(this, m_Enemy.mtm);
        begginingPhase = new BegginingPhase(this);
        mainPhase = new MainPhase(this);
        endPhase = new EndPhase(this);
        combatEndPhase = new CombatEndPhase(this);
    }
    private void Update() => m_CurrentState?.Update();
    public void ChangeState(CombatState newState)
    {
        if (newState == null || newState == m_CurrentState) return;
               
        m_CurrentState?.Exit();
        m_CurrentState = newState;
        m_CurrentState.Enter();
    }

    public void EnterEnemyPhase()
    {
        if(m_CurrentState == null || m_CurrentState == combatPhase)
        {
            ChangeState(enemyPhase);
        }
    }
    public void EnterPlayerTurn()
    {
        if(m_CurrentState == enemyPhase)
        {
            ChangeState(begginingPhase);
        }
    }
    public void EnterMainPhase()
    {
        if(m_CurrentState == begginingPhase)
            ChangeState(mainPhase);
    }
    public void EnterEndPhase()
    {
        if(m_CurrentState == mainPhase)
        {
            ChangeState(endPhase);
        }
    }
    public void EnterCombatPhase()
    {
        if (m_CurrentState == endPhase)
            ChangeState(combatPhase);
    }

    public void FinishCombat()
    {
        ChangeState(combatEndPhase);
    }

    public bool IsMainPhase()
    {
        return m_CurrentState == mainPhase;
    }
}