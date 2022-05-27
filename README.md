# WorkshopProj

#Bugs in this version to showcase debugging process:
* GetAxis instead of GetAxisRaw, line 40 (Slippery movement)

* line 43 change condition from m_onGround to !m_jump (Causes player to be able to jump multiple times)
* Remove reset of m_jump = false in line 93 (Causes player to not fall)

* Also issue with animation since i use == -1 (Cannot flip sprite properly)


#Things i will showcase in the live demo:
* Observer pattern: add a trigger for copycat, grab player and register its jump
* Singleton: do it for camera chake
* ObjectPooler: do an object pooler for the projectile