적 랜덤 인카운터 및 인벤토리 시스템 - 장착, 스테이터스 창 변화 구현.
>> 단, 아직 소모품 관련 SO/로직, UI는 미구현
>> 또한, 배틀씬에서 플레이어의 스킬셋에 따라 버튼 할당이 아직 되지 않음(NullReference)


적의 랜덤 인카운터의 경우, Coroutine을 이용하여 트리거 콜라이더 내에 있을 때(현재는 '배틀존' 타일맵에 해당)
3~6초의 랜덤한 시간에 따라, 확률적으로 시행되도록 함.


배틀씬에서 '도주' 선택시 아예 메인씬이 처음부터 로드되다 보니, 처음 시작 포지션에서 다시 시작하는 문제가 있었음.
캐릭터가 배틀에 진입할 때, 좌표를 저장하도록 하여 메인씬이 다시 로드될 때 해당 정보에 따라 위치를 다시 줌.
>> 그 외 정보(소지금 (미구현)), 인벤토리 및 장착에 따른 스탯변화 등도 씬이 이동할 때 변화하지 않도록 씬 이동 간에도
>> 데이터를 주고 받을 수 있도록 만들어 주고자 함.
