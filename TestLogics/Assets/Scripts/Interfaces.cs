using System.Collections;

/* Log
 * 인터페이스 선언을 모아놓은 스크립트 파일 
 * 생성자 : 이존하
 * 작업목록 
 * 2015.03.17 - 생성, IPauseNResume 선언  
 * 2015. . -
 */

public interface IPauseNResume{
    void Pause();
    void Resume();
    void RegisterPauseManager();
    void UnRegisterPauseManager();    
}

