--以下为对于一个建筑物的摆放，移除，移动操作

BUILD_OPTYPE_ADD = 1;
BUILD_OPTYPE_DEL = 2;
BUILD_OPTYPE_MOV = 3;

--协议部分(操作类型，数据库存储位置ID，建筑物ID，摆放的格子XY坐标)
function CBuilderProxy:Ctor( nType,nDBID,nBuildID,nGridX,nGridY )
	self.m_nType = nType;
	self.m_nDBID = nDBID;
	self.m_nBuildID = nBuildID;
	self.m_nGridX = nGridX;
	self.m_nGridY = nGridY;
end

function CBuilderProxy:OnPack( Buffer )
	Buffer:WriteUInt8( self.m_nType );
	Buffer:WriteUInt8( self.m_nDBID );
	Buffer:WriteUInt16( self.m_nBuildID );
	Buffer:WriteUInt8( self.m_nGridX );
	Buffer:WriteUInt8( self.m_nGridY );
end

function CBuilderProxy:UnPack( Buffer )
	self.m_nType = Buffer:ReadUInt8();
	self.m_nDBID = Buffer:ReadUInt8();
	self.m_nBuildID = Buffer:ReadUInt16();
	self.m_nGridX = Buffer:ReadUInt8();
	self.m_nGridY = Buffer:ReadUInt8();
end

function CBuilderProxy:OnNetRelay( Charcontextserver )
	local nRet = Charcontextserver:DoBuild( self.m_nType,self.m_nDBID,self.m_nBuildID,self.m_nGridX,self.m_nGridY );
	if nRet ~= ERT_OK then
		Charcontextserver:KickNotify();
	end
	return nRet;
end

--客户端
function CharcontexClient:DoBuild( nType,nDBID,nBuildID,nGridX,nGridY )
	local nRet = Charcontex:DoBuild( nType,nDBID,nBuildID,nGridX,nGridY );
	if nRet == ERT_OK then
		local msg = CBuilderProxy:New( nType,nDBID,nBuildID,nGridX,nGridY );
		Self:SendShellMsg( msg );
	end

	return nRet;
end

--客户端与服务端公共代码
function Charcontex:DoBuild( nType,nDBID,nBuildID,nGridX,nGridY )
	if not nType or not nDBID or not nBuildID or nType < BUILD_OPTYPE_ADD or nType > BUILD_OPTYPE_MOV then
		return ERT_INVALID_PARAM;
	end
	local tBuildConfig = g_data_build and g_data_build[nBuildID];
	if not tBuildConfig then
		return ERT_INVALID_PARAM;
	end
	local BuildDB = self.PlayerData.BuildData;
	local BuildData = BuildDB and BuildDB:GetBuildData( nDBID );
	if not BuildData then
		return ERT_NODBDATA;
	end
	if nType == BUILD_OPTYPE_ADD then
		BuildData:SetBuildID( nBuildID );
		BuildData:SetGridX( nGridX );
		BuildData:SetGridX( nGridY );
	elseif nType == BUILD_OPTYPE_DEL then
		BuildData:SetBuildID( 0 );
	elseif nType == BUILD_OPTYPE_MOV then
		BuildData:SetGridX( nGridX );
		BuildData:SetGridX( nGridY );
	end

	return ERT_OK;
end

--UI部分

function CBuildWnd:Ctor( wndParent )
	self.m_wndParent = wndParent;
end

function CBuildWnd:OnCreate()
	self.m_btnAddBuild = self:GetWndChild( "btn_add" );
	self.m_btnAddBuild:AddEventlistener( WM_LBTN_DOWN, "AddBuild",self );
end

function CBuildWnd:OnWndShow( bShow )

end

function CBuildWnd:Refresh()

end

function CBuildWnd:AddBuild()
	local CharcontexClient = g_APP:GetMainCharContext();
	local nDBID,nBuildID,nGridX,nGridY = UnPack( CharcontexClient:GetSelectBuildInfo() );
	local nRet = CharcontexClient:DoBuild( BUILD_OPTYPE_ADD, nDBID,nBuildID,nGridX,nGridY );
	if nRet == ERT_OK then
		self:Refresh();
	end
end
















