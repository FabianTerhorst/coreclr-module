#include "entity.h"

uint16_t Entity_GetID(alt::IEntity *entity)
{
    return entity->GetID();
}

void Entity_GetPositionRef(alt::IEntity *entity, alt::Position &pos)
{
    pos = entity->GetPosition();
}

void Entity_SetPositionRef(alt::IEntity *entity, alt::Position *pos)
{
    entity->SetPosition(*pos);
}

alt::Position Entity_GetPosition(alt::IEntity *entity)
{
    return entity->GetPosition();
}

void Entity_SetPosition(alt::IEntity *entity, alt::Position pos)
{
    entity->SetPosition(pos);
}

void Entity_SetPosition(alt::IEntity *entity, float x, float y, float z)
{
    entity->SetPosition(x, y, z);
}

void Entity_GetRotationRef(alt::IEntity *entity, alt::Rotation &rot)
{
    rot = entity->GetRotation();
}

void Entity_SetRotationRef(alt::IEntity *entity, alt::Rotation *rot)
{
    entity->SetRotation(*rot);
}

alt::Rotation Entity_GetRotation(alt::IEntity *entity)
{
    return entity->GetRotation();
}

void Entity_SetRotation(alt::IEntity *entity, alt::Rotation rot)
{
    entity->SetRotation(rot);
}

void Entity_SetRotationRPY(alt::IEntity *entity, float roll, float pitch, float yaw)
{
    entity->SetRotation(roll, pitch, yaw);
}

uint16_t Entity_GetDimension(alt::IEntity *entity)
{
    return entity->GetDimension();
}

void Entity_SetDimension(alt::IEntity *entity, uint16_t dimension)
{
    entity->SetDimension(dimension);
}

void Entity_GetMetaData(alt::IEntity *entity, const char *key, alt::MValue &val)
{
    val = entity->GetMetaData(key);
}

void Entity_SetMetaData(alt::IEntity *entity, const char *key, alt::MValue *val)
{
    entity->SetMetaData(key, *val);
}

void Entity_GetSyncedMetaData(alt::IEntity *entity, const char *key, alt::MValue &val)
{
    val = entity->GetSyncedMetaData(key);
}

void Entity_SetSyncedMetaData(alt::IEntity *entity, const char *key, alt::MValue *val)
{
    entity->SetSyncedMetaData(key, *val);
}
